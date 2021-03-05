using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.EventListeners
{
    public class GameObjectEventListenerTests
    {

        [Test]
        public void ScriptEventListenerHandleFunction_UnityEventCanBeInvokedDirectly()
        {
            // Arrange
            var eventListenerCalled = false;
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();

            unityEvent.AddListener(gameObject => eventListenerCalled = true);
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEvent.RegisterListener(gameObjectEventListener);

            // Act
            gameObjectEventListener.OnEventBroadcast(new GameObject());

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void ScriptEventListenerHandleFunction_CalledWithExpectedArgument()
        {
            // Arrange
            GameObject passedInArgument = null;
            var dummyGameObject = new GameObject();
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();

            unityEvent.AddListener(gameObject => passedInArgument = gameObject);
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEvent.RegisterListener(gameObjectEventListener);

            // Act
            gameObjectEventListener.OnEventBroadcast(dummyGameObject);

            // Assert
            Assert.AreSame(dummyGameObject, passedInArgument, "GameObject is passed in as a parameter");
        }

        [Test]
        public void OnGameObjectEventBroadcast_GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            // Arrange
            var eventListenerCalled = false;
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();

            unityEvent.AddListener(gameObject => eventListenerCalled = true);
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEvent.RegisterListener(gameObjectEventListener);

            // Act
            gameObjectEvent.Broadcast(new GameObject());

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void OnGameObjectEventBroadcast_CalledWithExpectedArgument()
        {
            // Arrange
            GameObject passedInArgument = null;
            var dummyGameObject = new GameObject();
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();

            unityEvent.AddListener(gameObject => passedInArgument = gameObject);
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEvent.RegisterListener(gameObjectEventListener);

            // Act
            gameObjectEvent.Broadcast(dummyGameObject);

            // Assert
            Assert.AreSame(dummyGameObject, passedInArgument, "GameObject is passed in as a parameter");
        }
    }
}
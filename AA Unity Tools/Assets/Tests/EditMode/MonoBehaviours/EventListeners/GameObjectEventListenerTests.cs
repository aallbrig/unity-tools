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
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEventListener.OnEnable();

            var dummyGameObject = new GameObject();
            unityEvent.AddListener(gameObject => eventListenerCalled = true);

            // Act
            gameObjectEventListener.OnEventBroadcast(dummyGameObject);

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void ScriptEventListenerHandleFunction_CalledWithExpectedArgument()
        {
            // Arrange
            GameObject gameObjectArgument = null;
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEventListener.OnEnable();
            var dummyGameObject = new GameObject();

            unityEvent.AddListener(gameObject => gameObjectArgument = gameObject);

            // Act
            gameObjectEventListener.OnEventBroadcast(dummyGameObject);

            // Assert
            Assert.AreSame(dummyGameObject, gameObjectArgument, "GameObject is passed in as a parameter");
        }

        [Test]
        public void OnGameObjectEventBroadcast_GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            // Arrange
            GameObject gameObjectArgument = null;
            var eventListenerCalled = false;
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEventListener.OnEnable();
            var dummyGameObject = new GameObject();

            unityEvent.AddListener(gameObject => eventListenerCalled = true);

            // Act
            gameObjectEvent.Broadcast(dummyGameObject);

            // Assert
            Assert.True(eventListenerCalled);
        }

        [Test]
        public void OnGameObjectEventBroadcast_CalledWithExpectedArgument()
        {
            // Arrange
            GameObject gameObjectArgument = null;
            var unityEvent = new GameObjectEventUnityEvent();
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEventListener.OnEnable();
            var dummyGameObject = new GameObject();

            unityEvent.AddListener(gameObject => gameObjectArgument = gameObject);

            // Act
            gameObjectEvent.Broadcast(dummyGameObject);

            // Assert
            Assert.AreSame(dummyGameObject, gameObjectArgument, "GameObject is passed in as a parameter");
        }
    }
}
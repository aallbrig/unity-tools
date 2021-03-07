using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.EventListeners
{
    public class OneObjectEventListenerTests
    {

        [Test]
        public void ScriptEventListenerHandleFunction_UnityEventCanBeInvokedDirectly()
        {
            // Arrange
            var eventListenerCalled = false;
            var gameObjectEvent = ScriptableObject.CreateInstance<OneObjectEventAlias>();
            var gameObjectEventListener = new GameObject().AddComponent<OneObjectEventListenerAlias>();
            var unityEvent = new OneObjectEventListener<GameObject>.OneObjectEventUnityEvent();

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
            var gameObjectEvent = ScriptableObject.CreateInstance<OneObjectEventAlias>();
            var gameObjectEventListener = new GameObject().AddComponent<OneObjectEventListenerAlias>();
            var unityEvent = new OneObjectEventListener<GameObject>.OneObjectEventUnityEvent();

            unityEvent.AddListener(gameObject => passedInArgument = gameObject);
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEvent.RegisterListener(gameObjectEventListener);

            // Act
            gameObjectEventListener.OnEventBroadcast(dummyGameObject);

            // Assert
            Assert.AreSame(dummyGameObject, passedInArgument);
        }

        [Test]
        public void OnOneObjectEventBroadcast_GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            // Arrange
            var eventListenerCalled = false;
            var gameObjectEvent = ScriptableObject.CreateInstance<OneObjectEventAlias>();
            var gameObjectEventListener = new GameObject().AddComponent<OneObjectEventListenerAlias>();
            var unityEvent = new OneObjectEventListener<GameObject>.OneObjectEventUnityEvent();

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
        public void OnOneObjectEventBroadcast_CalledWithExpectedArgument()
        {
            // Arrange
            GameObject passedInArgument = null;
            var dummyGameObject = new GameObject();
            var gameObjectEvent = ScriptableObject.CreateInstance<OneObjectEventAlias>();
            var gameObjectEventListener = new GameObject().AddComponent<OneObjectEventListenerAlias>();
            var unityEvent = new OneObjectEventListener<GameObject>.OneObjectEventUnityEvent();

            unityEvent.AddListener(gameObject => passedInArgument = gameObject);
            gameObjectEventListener.soEvent = gameObjectEvent;
            gameObjectEventListener.unityEvent = unityEvent;
            gameObjectEvent.RegisterListener(gameObjectEventListener);

            // Act
            gameObjectEvent.Broadcast(dummyGameObject);

            // Assert
            Assert.AreSame(dummyGameObject, passedInArgument);
        }

        // HACK: Alias because ScriptableObject.CreateInstance<OneObjectEvent<GameObject>>() does not work
        public class OneObjectEventAlias : OneObjectEvent<GameObject> {}

        // HACK: Alias because new GameObject.AddComponent<OneObjectEventListener<GameObject>>() does not work
        public class OneObjectEventListenerAlias : OneObjectEventListener<GameObject> {}
    }
}
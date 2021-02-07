using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.MonoBehaviours.EventListeners
{
    public class GameObjectEventListenerTests
    {
        private GameObjectEvent _gameObjectEvent;
        private GameObjectEventListener _gameObjectEventListener;
        private GameObjectEventUnityEvent _unityEvent;

        [SetUp]
        public void Setup()
        {
            _unityEvent = new GameObjectEventUnityEvent();

            _gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();

            _gameObjectEventListener = new GameObject().AddComponent<GameObjectEventListener>();
            _gameObjectEventListener.soEvent = _gameObjectEvent;
            _gameObjectEventListener.unityEvent = _unityEvent;
            _gameObjectEventListener.OnEnable();
        }

        [TearDown]
        public void TearDown()
        {
            _gameObjectEventListener.OnDisable();
            _gameObjectEventListener = null;
            _gameObjectEvent = null;
            _unityEvent = null;
        }

        [Test]
        public void UnityEventCanBeInvokedDirectly()
        {
            var dummyGameObject = new GameObject();
            _unityEvent.AddListener(gameObject =>
                Assert.AreSame(dummyGameObject, gameObject, "GameObject is passed in as a parameter"));

            _gameObjectEventListener.OnEventBroadcast(dummyGameObject);
        }

        [Test]
        public void GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            var dummyGameObject = new GameObject();
            _unityEvent.AddListener(gameObject =>
                Assert.AreSame(dummyGameObject, gameObject, "GameObject is passed in as a parameter"));

            _gameObjectEvent.Broadcast(dummyGameObject);
        }
    }
}
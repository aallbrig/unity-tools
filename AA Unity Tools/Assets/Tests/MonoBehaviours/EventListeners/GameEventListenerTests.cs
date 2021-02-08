using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.MonoBehaviours.EventListeners
{
    public class GameEventListenerTests
    {
        private GameEvent _gameEvent;
        private GameEventListener _gameEventListener;
        private UnityEvent _unityEvent;

        [SetUp]
        public void Setup()
        {
            _unityEvent = new UnityEvent();

            _gameEvent = ScriptableObject.CreateInstance<GameEvent>();

            _gameEventListener = new GameObject().AddComponent<GameEventListener>();
            _gameEventListener.soEvent = _gameEvent;
            _gameEventListener.unityEvent = _unityEvent;
            _gameEventListener.OnEnable();
        }

        [TearDown]
        public void TearDown()
        {
            _gameEventListener.OnDisable();
            _gameEventListener = null;
            _gameEvent = null;
            _unityEvent = null;
        }

        [Test]
        public void GameEventListenerUnityEventCanBeInvokedManually()
        {
            _unityEvent.AddListener(() => Assert.Pass("Unity Event listener invoked"));
            _gameEventListener.OnEventBroadcast();
        }

        [Test]
        public void GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            _unityEvent.AddListener(() => Assert.Pass("Unity Event listener invoked"));
            _gameEvent.Broadcast();
        }
    }
}
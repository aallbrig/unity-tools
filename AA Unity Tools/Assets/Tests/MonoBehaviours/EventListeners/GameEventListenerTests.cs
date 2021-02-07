using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.MonoBehaviours.EventListeners
{
    public class GameEventListenerTests
    {
        private GameEventListener _gameEventListener;
        private GameObject _gameObject;
        private GameEvent _testGameEvent;
        private UnityEvent _unityEvent;

        [SetUp]
        public void Setup()
        {
            _unityEvent = new UnityEvent();
            _unityEvent.AddListener(() => Assert.Pass("Unity Event listener invoked"));

            _testGameEvent = ScriptableObject.CreateInstance<GameEvent>();

            _gameObject = new GameObject();
            _gameEventListener = _gameObject.AddComponent<GameEventListener>();
            _gameEventListener.soEvent = _testGameEvent;
            _gameEventListener.unityEvent = _unityEvent;
            _gameEventListener.OnEnable();
        }

        [TearDown]
        public void TearDown()
        {
            _gameEventListener.OnDisable();
            _gameEventListener = null;
            _gameObject = null;
            _testGameEvent = null;
        }

        [Test] public void GameEventListenerUnityEventCanBeInvokedManually() => _gameEventListener.OnEventBroadcast();

        [Test] public void GameEventListenerInvokesUnityEventOnGameEventBroadcast() => _testGameEvent.Broadcast();
    }
}
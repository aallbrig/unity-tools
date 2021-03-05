using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.EditMode.MonoBehaviours.EventListeners
{
    public class GameEventListenerTests
    {
        [Test]
        public void GameEventListenerUnityEventCanBeInvokedManually()
        {
            // Arrange
            var called = false;
            var unityEvent = new UnityEvent();
            var gameEventListener = new GameObject().AddComponent<GameEventListener>();

            unityEvent.AddListener(() => called = true);
            gameEventListener.unityEvent = unityEvent;

            // Action
            gameEventListener.OnEventBroadcast();

            // Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void GameEventListenerInvokesUnityEventOnGameEventBroadcast()
        {
            // Arrange
            var called = false;
            var unityEvent = new UnityEvent();
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventListener = new GameObject().AddComponent<GameEventListener>();

            unityEvent.AddListener(() => called = true);
            gameEventListener.unityEvent = unityEvent;
            gameEventListener.soEvent = gameEvent;
            gameEvent.RegisterListener(gameEventListener);

            // Action
            gameEvent.Broadcast();

            // Assert
            Assert.IsTrue(called);
        }
    }
}
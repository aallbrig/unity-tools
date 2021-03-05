using MonoBehaviours.EventListeners;
using MonoBehaviours.EventProducers;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.EditMode.MonoBehaviours.EventProducers
{
    public class GameEventOnDisableProducerTests : MonoBehaviour
    {
        [Test]
        public void GameEventIsBroadcastOnDisableTests()
        {
            // Arrange
            var eventListenerCalled = false;
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventProducer = new GameObject().AddComponent<GameEventOnDisableProducer>();
            var gameEventListener = new GameObject().AddComponent<GameEventListener>();
            var unityEvent = new UnityEvent();

            gameEventProducer.gameEvents.Add(gameEvent);
            gameEventListener.soEvent = gameEvent;
            gameEventListener.unityEvent = unityEvent;
            unityEvent.AddListener(() => eventListenerCalled = true);
            gameEvent.RegisterListener(gameEventListener);

            // Act
            gameEventProducer.OnDisable();

            // Assert
            Assert.True(eventListenerCalled);
        }
    }
}
using MonoBehaviours.EventListeners;
using MonoBehaviours.EventProducers;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.EditMode.MonoBehaviours.EventProducers
{
    public class GameEventOnEnableProducerTests : MonoBehaviour
    {
        [Test]
        public void GameEventIsBroadcastOnEnable()
        {
            // Arrange
            var eventListenerCalled = false;
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var gameEventProducer = new GameObject().AddComponent<GameEventOnEnableProducer>();
            var gameEventListener = new GameObject().AddComponent<GameEventListener>();
            var unityEvent = new UnityEvent();

            gameEventProducer.gameEvents.Add(gameEvent);
            gameEventListener.soEvent = gameEvent;
            gameEventListener.unityEvent = unityEvent;
            unityEvent.AddListener(() => eventListenerCalled = true);
            gameEvent.RegisterListener(gameEventListener);

            // Act
            gameEventProducer.OnEnable();

            // Assert
            Assert.True(eventListenerCalled);
        }
    }
}
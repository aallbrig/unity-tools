using MonoBehaviours.EventListeners;
using MonoBehaviours.EventProducers;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.MonoBehaviours.EventProducers
{
    public class SceneEventOnDisableProducerTests : MonoBehaviour
    {
        [Test]
        public void SceneEventIsBroadcastOnDisable()
        {
            // Arrange
            var eventListenerCalled = false;
            var sceneEvent = ScriptableObject.CreateInstance<SceneEvent>();
            var sceneEventProducer = new GameObject().AddComponent<SceneEventOnDisableProducer>();
            sceneEventProducer.sceneEvents.Add(sceneEvent);

            var sceneEventListener = new GameObject().AddComponent<SceneEventListener>();
            var unityEvent = new UnityEvent();
            sceneEventListener.soEvent = sceneEvent;
            sceneEventListener.unityEvent = unityEvent;
            unityEvent.AddListener(() => eventListenerCalled = true);
            sceneEventListener.OnEnable();

            // Act
            sceneEventProducer.OnDisable();

            // Assert
            Assert.True(eventListenerCalled);
        }
    }
}
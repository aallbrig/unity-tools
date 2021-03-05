using MonoBehaviours.EventListeners;
using MonoBehaviours.EventProducers;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.EditMode.MonoBehaviours.EventProducers
{
    public class SceneEventOnEnableProducerTests : MonoBehaviour
    {
        [Test]
        public void SceneEventIsBroadcastOnEnable()
        {
            // Arrange
            var eventListenerCalled = false;
            var sceneEvent = ScriptableObject.CreateInstance<SceneEvent>();
            var sceneEventProducer = new GameObject().AddComponent<SceneEventOnEnableProducer>();
            var sceneEventListener = new GameObject().AddComponent<SceneEventListener>();
            var unityEvent = new UnityEvent();

            sceneEventProducer.sceneEvents.Add(sceneEvent);
            sceneEventListener.soEvent = sceneEvent;
            sceneEventListener.unityEvent = unityEvent;
            unityEvent.AddListener(() => eventListenerCalled = true);
            sceneEventListener.OnEnable();

            // Act
            sceneEventProducer.OnEnable();

            // Assert
            Assert.True(eventListenerCalled);
        }
    }
}
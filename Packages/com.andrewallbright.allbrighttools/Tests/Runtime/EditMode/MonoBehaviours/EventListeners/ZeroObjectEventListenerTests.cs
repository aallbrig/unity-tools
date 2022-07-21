using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.Runtime.EditMode.MonoBehaviours.EventListeners
{
    public class ZeroObjectEventListenerTests
    {

        [Test]
        public void ZeroObjectEventListenerUnityEventCanBeInvokedManually()
        {
            // Arrange
            var called = false;
            var unityEvent = new UnityEvent();
            unityEvent.AddListener(() => called = true);
            var gameEventListener = new GameObject().AddComponent<ZeroObjectEventListenerAlias>();
            gameEventListener.unityEvent = unityEvent;

            // Action
            gameEventListener.OnEventBroadcast();

            // Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void ZeroObjectEventListenerInvokesUnityEventOnZeroObjectEventBroadcast()
        {
            // Arrange
            var called = false;
            var unityEvent = new UnityEvent();
            unityEvent.AddListener(() => called = true);
            var gameEvent = ScriptableObject.CreateInstance<ZeroObjectEvent>();
            var gameEventListener = new GameObject().AddComponent<ZeroObjectEventListenerAlias>();
            gameEventListener.unityEvent = unityEvent;
            gameEventListener.soEvent = gameEvent;
            gameEvent.RegisterListener(gameEventListener);

            // Action
            gameEvent.Broadcast();

            // Assert
            Assert.IsTrue(called);
        }

        // HACK: new GameObject().AddComponent<ZeroObjectEventListener<ZeroObjectEvent>>() does not work
        public class ZeroObjectEventListenerAlias : ZeroObjectEventListener<ZeroObjectEvent> {}
    }
}
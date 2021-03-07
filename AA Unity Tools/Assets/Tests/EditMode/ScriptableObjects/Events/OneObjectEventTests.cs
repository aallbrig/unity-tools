using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Events
{
    public class OneObjectEventTests
    {
        [Test]
        public void OneObjectEvent_BroadcastReceivedByListener_Single()
        {
            var evt = ScriptableObject.CreateInstance<OneObjectEventAlias>();
            var payload = new Object();
            var eventListener = Substitute.For<IOneObjectEventListener<Object>>();
            evt.RegisterListener(eventListener);

            evt.Broadcast(payload);

            eventListener.Received().OnEventBroadcast(payload);
        }

        [Test]
        public void OneObjectEvent_BroadcastReceivedByListener_Multiple()
        {
            var evt = ScriptableObject.CreateInstance<OneObjectEventAlias>();
            var payload = new Object();
            var eventListenerA = Substitute.For<IOneObjectEventListener<Object>>();
            var eventListenerB = Substitute.For<IOneObjectEventListener<Object>>();
            var eventListenerC = Substitute.For<IOneObjectEventListener<Object>>();
            evt.RegisterListener(eventListenerA);
            evt.RegisterListener(eventListenerB);
            evt.RegisterListener(eventListenerC);

            evt.Broadcast(payload);

            eventListenerA.Received().OnEventBroadcast(payload);
            eventListenerB.Received().OnEventBroadcast(payload);
            eventListenerC.Received().OnEventBroadcast(payload);
        }

        // HACK: Alias required because ScriptableObject.CreateInstance<OneObjectEvent<Object>>() does not work
        public class OneObjectEventAlias : OneObjectEvent<Object> {}
    }
}
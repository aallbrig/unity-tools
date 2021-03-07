using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Events
{
    public class ZeroObjectEventTests
    {
        [Test]
        public void OneObjectEvent_Broadcast_ReceivedByListener()
        {
            var evt = ScriptableObject.CreateInstance<ZeroObjectEvent>();
            var eventListener = Substitute.For<IZeroObjectEventListener>();

            evt.RegisterListener(eventListener);
            evt.Broadcast();

            eventListener.Received().OnEventBroadcast();
        }
    }
}
using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Events
{
    public class GameEventTests
    {
        [Test]
        public void GameEvent_Can_Broadcast()
        {
            var evt = ScriptableObject.CreateInstance<GameEvent>();
            var eventListener = Substitute.For<IZeroObjectEventListener>();
            evt.RegisterListener(eventListener);

            evt.Broadcast();

            eventListener.Received().OnEventBroadcast();
        }
    }
}
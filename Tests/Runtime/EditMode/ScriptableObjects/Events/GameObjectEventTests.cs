using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.Runtime.EditMode.ScriptableObjects.Events
{
    public class GameObjectEventTests
    {
        [Test]
        public void GameObjectEvent_Can_Broadcast()
        {
            var evt = ScriptableObject.CreateInstance<GameObjectEvent>();
            var evtListener = Substitute.For<IOneObjectEventListener<GameObject>>();
            evt.RegisterListener(evtListener);
            var payload = new GameObject();

            evt.Broadcast(payload);

            evtListener.Received().OnEventBroadcast(payload);
        }
    }
}
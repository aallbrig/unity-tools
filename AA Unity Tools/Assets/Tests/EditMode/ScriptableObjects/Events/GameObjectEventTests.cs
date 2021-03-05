using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Events
{
    public class GameObjectEventTests
    {
        [Test]
        public void ScriptableObject_Exists() =>
            Assert.NotNull(ScriptableObject.CreateInstance<GameObjectEvent>());

        [Test]
        public void GameObjectEvent_Broadcast_Received()
        {
            var evt = ScriptableObject.CreateInstance<GameObjectEvent>();
            var eventListener = Substitute.For<IGameObjectEventListener<GameObject>>();
            var payload = new GameObject();

            evt.RegisterListener(eventListener);
            evt.Broadcast(payload);

            eventListener.Received().OnEventBroadcast(payload);
        }
    }
}
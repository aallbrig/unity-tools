using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Events
{
    public class GameEventTests
    {
        [Test]
        public void ScriptableObject_Exists() =>
            Assert.NotNull(ScriptableObject.CreateInstance<GameEvent>());
    }
}
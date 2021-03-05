using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.RuntimeSets
{
    // HACK: Alias must exist because ScriptableObject.CreateInstance<RuntimeSet<Object>> does not work
    public class RuntimeSetAlias : RuntimeSet<Object> {}

    public class RuntimeSet
    {
        [Test]
        public void RuntimeSet_CanBe_Created()
        {
            Assert.NotNull(ScriptableObject.CreateInstance<RuntimeSetAlias>());
        }

        [Test]
        public void RuntimeSet_CanBe_Reset()
        {
            var runtimeSet = ScriptableObject.CreateInstance<RuntimeSetAlias>();
            runtimeSet.list.Add(new Object());
            runtimeSet.list.Add(new Object());
            runtimeSet.list.Add(new Object());
            runtimeSet.list.Add(new Object());
            runtimeSet.list.Add(new Object());

            runtimeSet.Reset();

            Assert.AreEqual(0, runtimeSet.list.Count);
        }

        [Test]
        public void RuntimeSet_Can_AddItems()
        {
            var runtimeSet = ScriptableObject.CreateInstance<RuntimeSetAlias>();

            runtimeSet.Add(new Object());

            Assert.AreEqual(1, runtimeSet.list.Count);
        }

        [Test]
        public void RuntimeSet_Can_RemoveItems()
        {
            var runtimeSet = ScriptableObject.CreateInstance<RuntimeSetAlias>();
            var listItem = new Object();

            runtimeSet.Add(listItem);
            Assert.AreEqual(1, runtimeSet.list.Count);
            runtimeSet.Remove(listItem);

            Assert.AreEqual(0, runtimeSet.list.Count);
        }
    }
}
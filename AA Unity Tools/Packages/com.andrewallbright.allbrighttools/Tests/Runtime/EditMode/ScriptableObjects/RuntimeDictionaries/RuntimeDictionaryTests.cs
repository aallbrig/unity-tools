using NUnit.Framework;
using ScriptableObjects.RuntimeDictionaries;
using UnityEngine;

namespace Tests.Runtime.EditMode.ScriptableObjects.RuntimeDictionaries
{
    public class RuntimeDictionaryAlias : RuntimeDictionary<GameObject, GameObject> {}

    public class RuntimeDictionaryTests
    {
        [Test] public void CanBe_Created() => Assert.NotNull(ScriptableObject.CreateInstance<RuntimeDictionaryAlias>());
        [Test]
        public void CanBe_Reset()
        {
            var instance = ScriptableObject.CreateInstance<RuntimeDictionaryAlias>();
            instance.dictionary[new GameObject()] = new GameObject();
            
            instance.Reset();
            
            Assert.AreEqual(0, instance.dictionary.Count);
        }
    }
}
using NUnit.Framework;
using ScriptableObjects.Refs;
using ScriptableObjects.Vars;
using UnityEngine;

namespace Tests.Runtime.EditMode.ScriptableObjects.Refs
{
    // HACK: VarAlias because ScriptableObject.CreateInstance<VarAlias<GameObject>> does not work
    public class VarAlias : Var<GameObject> {}

    // HACK: RefAlias because ScriptableObject.CreateInstance<Ref<GameObject>> does not work
    public class RefAlias : Ref<VarAlias, GameObject> {}

    public class RefTests
    {
        [Test] public void Ref_StartsOut_ReturningDynamicValue() => Assert.False(new RefAlias().useConstant);
        [Test]
        public void Ref_CanReturn_DynamicValue()
        {
            var dummyGameObject = new GameObject();
            var refInstance = new RefAlias();
            refInstance.useConstant = false;
            refInstance.var = dummyGameObject;

            var returnedValue = refInstance.Value;

            Assert.AreEqual(dummyGameObject, returnedValue);
        }
        [Test]
        public void Ref_CanReturn_ConstantValue()
        {
            var dummyGameObject = new GameObject();
            var varInstance = ScriptableObject.CreateInstance<VarAlias>();
            varInstance.value = dummyGameObject;
            var refInstance = new RefAlias();
            refInstance.useConstant = true;
            refInstance.constantValue = varInstance;

            var returnedValue = refInstance.Value;

            Assert.AreEqual(dummyGameObject, returnedValue);
        }
    }
}
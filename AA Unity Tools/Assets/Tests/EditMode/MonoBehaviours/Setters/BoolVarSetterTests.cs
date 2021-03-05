using MonoBehaviours.Setters;
using NUnit.Framework;
using ScriptableObjects.Vars;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Setters
{
    public class BoolVarSetterTests
    {
        [Test] public void Script_Exists() => Assert.NotNull(new GameObject().AddComponent<BoolVarSetter>());

        [Test]
        public void Var_CanBe_Set()
        {
            var script = new GameObject().AddComponent<BoolVarSetter>();
            var targetVar = ScriptableObject.CreateInstance<BoolVar>();
            var newValue = true;
            targetVar.value = false;
            script.var = targetVar;

            script.SetVarValue(newValue);

            Assert.AreEqual(newValue, targetVar.value);
        }

        [Test]
        public void Var_CanBe_Reset()
        {
            var script = new GameObject().AddComponent<BoolVarSetter>();
            var targetVar = ScriptableObject.CreateInstance<BoolVar>();
            targetVar.value = true;
            script.var = targetVar;

            script.ResetVarValue();

            Assert.IsFalse(targetVar.value);
        }
    }
}
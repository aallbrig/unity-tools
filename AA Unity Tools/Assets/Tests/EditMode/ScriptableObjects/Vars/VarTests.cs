﻿using NUnit.Framework;
using ScriptableObjects.Vars;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.Vars
{
    // HACK: Alias Var because ScriptableObject.CreateInstance<Var<GameObject>>() does not work
    // INFO: Interesting, I tried the "Var_Can_HaveValueUpdate" with "VarAlias: Var<Object>" but "varInstance = new Object()"
    // INFO: set value was still null! Updated to GameObject because new GameObject() != null
    public class VarAlias : Var<GameObject> {}

    public class VarTests
    {
        [Test] public void ScriptableObject_Exists() => Assert.NotNull(ScriptableObject.CreateInstance<VarAlias>());
        [Test] public void Var_Starts_WithoutAValue() => Assert.Null(ScriptableObject.CreateInstance<VarAlias>().value);
        [Test]
        public void Var_Can_HaveValueUpdate()
        {
            var varInstance = ScriptableObject.CreateInstance<VarAlias>();

            varInstance.value = new GameObject();

            Assert.NotNull(varInstance.value);
        }
    }
}
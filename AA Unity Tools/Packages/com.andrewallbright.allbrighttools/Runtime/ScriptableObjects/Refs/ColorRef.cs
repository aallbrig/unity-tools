using System;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.Refs
{
    [Serializable]
    public class ColorRef
    {
        public bool useConstant;
        public ColorVar constantValue;
        public Color var = Color.white;

        public Color Value => useConstant ? constantValue.value : var;
    }
}
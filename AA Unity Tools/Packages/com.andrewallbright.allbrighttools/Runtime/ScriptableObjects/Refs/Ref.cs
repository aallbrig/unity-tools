using System;
using ScriptableObjects.Vars;

namespace ScriptableObjects.Refs
{
    [Serializable]
    public abstract class Ref<T, TU> where T : Var<TU>
    {
        public bool useConstant;
        public T constantValue;
        public TU var;

        public TU Value => useConstant ? constantValue.value : var;
    }
}
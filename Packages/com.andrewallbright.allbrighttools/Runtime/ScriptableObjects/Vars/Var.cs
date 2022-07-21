using UnityEngine;

namespace ScriptableObjects.Vars
{
    public class Var<T> : ScriptableObject
    {
        public T value;

        public void SetVar(T varValue) => value = varValue;

        public void ResetVar() => value = default;
    }
}
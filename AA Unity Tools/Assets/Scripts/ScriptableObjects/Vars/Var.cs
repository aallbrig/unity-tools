using UnityEngine;

namespace ScriptableObjects.Vars
{
    public class Var<T> : ScriptableObject
    {
        public T value;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.RuntimeDictionaries
{
    public abstract class RuntimeDictionary<T, U> : ScriptableObject
    {
        public readonly Dictionary<T, U> dictionary = new Dictionary<T, U>();

        public void Reset() => dictionary.Clear();
        private void OnEnable() => Reset();
    }
}
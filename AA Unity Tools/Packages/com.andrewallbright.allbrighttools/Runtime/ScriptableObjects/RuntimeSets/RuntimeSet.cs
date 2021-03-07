using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.RuntimeSets
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> list = new List<T>();

        private void Awake() => Reset();

        public void Reset() => list.Clear();
        private void OnEnable() => Reset();
        private void OnDisable() => Reset();
        private void OnDestroy() => Reset();

        public void Add(T listItem)
        {
            if (!list.Contains(listItem)) list.Add(listItem);
        }

        public void Remove(T listItem)
        {
            if (list.Contains(listItem)) list.Remove(listItem);
        }
    }
}
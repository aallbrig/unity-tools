using ScriptableObjects.Refs;
using UnityEngine;

namespace MonoBehaviours.Customizers
{
    public abstract class Customizer : MonoBehaviour
    {
        [Tooltip("Update at runtime (useful when actively changing)")]
        public BoolRef updateAtRuntime;

        protected virtual void Update()
        {
            if (!updateAtRuntime.Value) return;

            Customize();
        }

        protected abstract void Customize();
    }
}
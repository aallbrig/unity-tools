using Interfaces;
using ScriptableObjects.Vars;
using UnityEngine;

namespace MonoBehaviours.Setters
{
    public class GameObjectVarSetter : MonoBehaviour, IVarSetter<GameObject>
    {
        public GameObjectVar var;

        private void OnEnable() => SetVarValue(gameObject);
        private void OnDisable() => ResetVarValue();
        public void SetVarValue(GameObject val) => var.value = val;
        public void ResetVarValue() => var.value = null;
    }
}
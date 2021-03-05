using Interfaces;
using ScriptableObjects.Vars;
using UnityEngine;

namespace MonoBehaviours.Setters
{
    public class BoolVarSetter : MonoBehaviour, IVarSetter<bool>
    {
        public BoolVar var;
        public void SetVarValue(bool val) => var.value = val;
        public void ResetVarValue() => var.value = false; // false is the default value for bools
    }
}
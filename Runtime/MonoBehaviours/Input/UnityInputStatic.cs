using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Input
{
    public class UnityInputStatic : MonoBehaviour, IInput
    {
        public float GetAxis(string axisName) => UnityEngine.Input.GetAxis(axisName);
    }
}
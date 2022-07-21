using ScriptableObjects.Refs;
using UnityEngine;

namespace MonoBehaviours.Customizers
{
    public class ConstantRotation : MonoBehaviour
    {
        public FloatRef rotationSpeed = new FloatRef {var = 10.0f};
        private Transform _transform;
        private void Update() => _transform.Rotate(0, rotationSpeed.Value * Time.deltaTime, 0);

        private void OnEnable() => _transform = transform;
    }
}
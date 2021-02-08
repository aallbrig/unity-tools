using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidBodyForceMovement : MonoBehaviour, IMoveable
    {
        public float speed = 1.0f;
        public ForceMode forceMode = ForceMode.Force;
        private Rigidbody _rigidbody;

        private void Start() => _rigidbody = GetComponent<Rigidbody>();

        public void Move(Vector3 direction)
        {
            var directionWithSpeed = direction * (speed * Time.deltaTime);
            _rigidbody.AddForce(directionWithSpeed.x, directionWithSpeed.y, directionWithSpeed.z, forceMode);
        }
    }
}
using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidBodyMovePositionMovement : MonoBehaviour, IMoveable
    {
        public float speed = 1.0f;
        public ForceMode forceMode = ForceMode.Force;
        private Rigidbody _rigidbody;
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction) =>
            _rigidbody.MovePosition(_transform.position + direction * (speed * Time.deltaTime));
    }
}
using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Movement
{
    public class TransformMovement : MonoBehaviour, IMoveable
    {
        public float speed = 1.0f;
        private Transform _transform;

        private void Start() => _transform = GetComponent<Transform>();

        public void Move(Vector3 direction) => _transform.position += direction * (speed * Time.deltaTime);
    }
}
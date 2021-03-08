using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace MonoBehaviours.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshAgentMovement : MonoBehaviour, IMoveable
    {
        public float speed = 1.0f;
        private NavMeshAgent _agent;
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Move(Vector3 direction)
        {
            var destination = _transform.position + direction * (speed * Time.deltaTime);
            _agent.SetDestination(destination);
        }
    }
}
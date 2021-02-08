using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class WASDInputController : MonoBehaviour
    {
        // WASD Input controller either works on self or a target
        [Tooltip("Optional target to apply WASD movement (default: self)")]
        public GameObject moveTarget;

        private IMoveable _moveController;

        private void Start() => _moveController = (moveTarget != null ? moveTarget : gameObject).GetComponent<IMoveable>();

        private void Update()
        {
            if (_moveController == null)
            {
                Debug.LogError("[WASD Input] IMoveable interface must be implemented");
                return;
            }

            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveController.Move(direction);
        }
    }
}
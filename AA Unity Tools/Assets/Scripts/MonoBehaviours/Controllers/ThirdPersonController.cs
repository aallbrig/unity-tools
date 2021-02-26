using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class ThirdPersonController : MonoBehaviour
    {
        // WASD Input controller either works on self or a target
        [Tooltip("Optional target to apply WASD movement (default: self)")]
        public GameObject moveTarget;
        [Tooltip("Optional target to apply rotation movement (default: self)")]
        public GameObject rotateTarget;
        [Tooltip("Optional target to receive movement input from (default: self)")]
        public GameObject inputTarget;

        private IMoveable _moveController;
        private IRotateable _rotateController;
        private IInput _input;

        private void Start()
        {
            _moveController = (moveTarget != null ? moveTarget : gameObject).GetComponent<IMoveable>();
            _rotateController = (rotateTarget != null ? rotateTarget : gameObject).GetComponent<IRotateable>();
            _input = (inputTarget != null ? inputTarget : gameObject).GetComponent<IInput>();
        }

        private void Update()
        {
            if (_moveController != null)
            {
                var direction = new Vector3(0, 0, _input.GetAxis("Vertical"));
                _moveController.Move(direction);
            }
            else Debug.LogWarning("[WASD Input] IMoveable interface should be implemented");

            if (_rotateController != null)
            {
                var rotation = new Vector3(0, _input.GetAxis("Horizontal"), 0);
                _rotateController.Rotate(rotation);
            }
            else Debug.LogWarning("[WASD Input] IRotateable interface should be implemented");
        }
    }
}
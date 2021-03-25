using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class WASDInputController : MonoBehaviour
    {
        [Tooltip("Optional target to base forward on (default: self)")]
        public GameObject forwardRelativeTo;

        [Tooltip("Optional target to receive movement input from (default: self)")]
        public GameObject inputSource;

        [Tooltip("Optional target to apply WASD movement (default: self)")]
        public GameObject moveTarget;

        public Transform ForwardTransform { get; set; }

        public IInput Input { get; set; }

        public IMoveable Move { get; set; }

        public void HandleMovementInput()
        {
            if (Move == null)
            {
                Debug.LogError("[WASD Input] IMoveable interface must be implemented");
                return;
            }

            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            var rotatedDirection = new Quaternion(0, ForwardTransform.rotation.eulerAngles.y, 0, 0) * direction;
            Move.Move(direction);
        }

        private void Start()
        {
            CacheInputComponent();
            CacheMoveComponent();
            CacheForwardRelativeToTransform();
        }

        private void Update()
        {
            HandleMovementInput();
        }

        private void OnEnable()
        {
            CacheInputComponent();
            CacheMoveComponent();
            CacheForwardRelativeToTransform();
        }

        private void CacheInputComponent() => Input = (inputSource != null ? inputSource : gameObject).GetComponent<IInput>();
        private void CacheMoveComponent() => Move = (moveTarget != null ? moveTarget : gameObject).GetComponent<IMoveable>();
        private void CacheForwardRelativeToTransform() =>
            ForwardTransform = (forwardRelativeTo != null ? forwardRelativeTo : gameObject).transform;
    }
}
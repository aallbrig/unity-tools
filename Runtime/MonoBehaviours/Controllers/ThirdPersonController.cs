using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class ThirdPersonController : MonoBehaviour
    {
        [Tooltip("Optional target to receive movement input from (default: self)")]
        public GameObject inputSource;

        [Tooltip("Optional target to apply WASD movement (default: self)")]
        public GameObject moveTarget;

        [Tooltip("Optional target to apply rotation movement (default: self)")]
        public GameObject rotateTarget;

        public IInput Input { get; set; }

        public IMoveable Move { get; set; }

        public IRotateable Rotate { get; set; }

        private void Start()
        {
            CacheInputComponent();
            CacheMoveComponent();
            CacheRotateComponent();
        }

        public void Update()
        {
            if (Input == null) Debug.LogWarning("[Third Person Controller] IInput interface is null");

            if (Move != null && Input != null)
            {
                var direction = new Vector3(0, 0, Input.GetAxis("Vertical"));
                Move.Move(direction);
            }
            else
            {
                Debug.LogWarning("[Third Person Controller] IMoveable interface is null");
            }

            if (Rotate != null && Input != null)
            {
                var rotation = new Vector3(0, Input.GetAxis("Horizontal"), 0);
                Rotate.Rotate(rotation);
            }
            else
            {
                Debug.LogWarning("[Third Person Controller] IRotateable interface is null");
            }
        }

        private void OnEnable()
        {
            CacheInputComponent();
            CacheMoveComponent();
            CacheRotateComponent();
        }

        private void CacheInputComponent() => Input = (inputSource != null ? inputSource : gameObject).GetComponent<IInput>();
        private void CacheMoveComponent() => Move = (moveTarget != null ? moveTarget : gameObject).GetComponent<IMoveable>();
        private void CacheRotateComponent() =>
            Rotate = (rotateTarget != null ? rotateTarget : gameObject).GetComponent<IRotateable>();
    }
}
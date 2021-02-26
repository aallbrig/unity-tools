using Interfaces;
using UnityEngine;

namespace MonoBehaviours.Controllers
{
    public class WASDInputController : MonoBehaviour
    {
        [Tooltip("Optional target to receive movement input from (default: self)")]
        public GameObject inputSource;

        [Tooltip("Optional target to apply WASD movement (default: self)")]
        public GameObject moveTarget;


        public IInput Input { get; set; }

        public IMoveable Move { get; set; }

        private void Start()
        {
            CacheInputComponent();
            CacheMoveComponent();
        }

        public void Update()
        {
            if (Move == null)
            {
                Debug.LogError("[WASD Input] IMoveable interface must be implemented");
                return;
            }

            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Move.Move(direction);
        }

        private void OnEnable()
        {
            CacheInputComponent();
            CacheMoveComponent();
        }

        private void CacheInputComponent() => Input = (inputSource != null ? inputSource : gameObject).GetComponent<IInput>();
        private void CacheMoveComponent() => Move = (moveTarget != null ? moveTarget : gameObject).GetComponent<IMoveable>();
    }
}
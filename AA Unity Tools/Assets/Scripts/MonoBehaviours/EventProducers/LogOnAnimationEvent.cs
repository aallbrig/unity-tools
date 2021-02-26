using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class LogOnAnimationEvent : MonoBehaviour
    {
        public void OnAnimationEvent() => Debug.Log("[LogOnAnimationEvent] Animation event has fired");
    }
}
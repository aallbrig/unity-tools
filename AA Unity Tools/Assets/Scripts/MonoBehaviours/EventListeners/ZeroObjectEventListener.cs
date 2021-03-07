using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{
    public class ZeroObjectEventListener<TEvent> : MonoBehaviour, IZeroObjectEventListener where TEvent : ZeroObjectEvent
    {
        public TEvent soEvent;
        public UnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);

        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast() => unityEvent.Invoke();
    }
}
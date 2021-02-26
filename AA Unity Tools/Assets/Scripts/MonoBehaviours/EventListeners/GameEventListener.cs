using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEvent soEvent;
        public UnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);

        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast() => unityEvent.Invoke();
    }
}
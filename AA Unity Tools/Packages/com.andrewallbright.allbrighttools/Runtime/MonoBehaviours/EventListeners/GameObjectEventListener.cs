using System;
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{
    public class GameObjectEventListener : MonoBehaviour, IOneObjectEventListener<GameObject>
    {

        public GameObjectEvent soEvent;
        public GameObjectEventUnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);
        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast(GameObject eventPayload) => unityEvent.Invoke(eventPayload);

        [Serializable] public class GameObjectEventUnityEvent : UnityEvent<GameObject> {}
    }
}
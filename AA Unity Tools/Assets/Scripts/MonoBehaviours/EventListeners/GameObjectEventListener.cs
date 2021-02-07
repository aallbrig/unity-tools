using System;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{
    [Serializable] public class GameObjectEventUnityEvent : UnityEvent<GameObject> {}

    public class GameObjectEventListener : MonoBehaviour
    {
        public GameObjectEvent soEvent;
        public GameObjectEventUnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);

        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast(GameObject go) => unityEvent.Invoke(go);
    }
}
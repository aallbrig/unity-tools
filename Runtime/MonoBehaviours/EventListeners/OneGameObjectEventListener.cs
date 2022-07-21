using System;
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours.EventListeners
{

    public class OneObjectEventListener<TObject> : MonoBehaviour, IOneObjectEventListener<TObject>
    {
        public OneObjectEvent<TObject> soEvent;
        public OneObjectEventUnityEvent unityEvent;

        public void OnEnable() => soEvent.RegisterListener(this);

        public void OnDisable() => soEvent.UnregisterListener(this);

        public void OnEventBroadcast(TObject objectOne) => unityEvent.Invoke(objectOne);

        [Serializable] public class OneObjectEventUnityEvent : UnityEvent<TObject> {}
    }
}
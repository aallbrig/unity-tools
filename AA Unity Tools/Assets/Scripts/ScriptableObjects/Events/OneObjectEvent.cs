using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Events
{
    public class OneObjectEvent<T> : ScriptableObject
    {
        private readonly List<IOneObjectEventListener<T>> _listeners = new List<IOneObjectEventListener<T>>();

        public void Broadcast(T argument)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast(argument);
        }

        public void RegisterListener(IOneObjectEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IOneObjectEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
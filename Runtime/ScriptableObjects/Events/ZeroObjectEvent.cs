using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Events
{
    public class ZeroObjectEvent : ScriptableObject
    {
        private readonly List<IZeroObjectEventListener> _listeners = new List<IZeroObjectEventListener>();

        public void Broadcast()
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast();
        }

        public void RegisterListener(IZeroObjectEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IZeroObjectEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
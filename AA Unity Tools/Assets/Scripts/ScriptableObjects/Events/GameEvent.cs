using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "new game event", menuName = "AATools/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

        public void Broadcast()
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast();
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
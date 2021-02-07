using System.Collections.Generic;
using MonoBehaviours.EventListeners;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "new game object event", menuName = "AATools/Events/GameObjectEvent")]
    public class GameObjectEvent : ScriptableObject
    {
        private readonly List<GameObjectEventListener> _listeners = new List<GameObjectEventListener>();

        public void Broadcast(GameObject go)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast(go);
        }

        public void RegisterListener(GameObjectEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(GameObjectEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
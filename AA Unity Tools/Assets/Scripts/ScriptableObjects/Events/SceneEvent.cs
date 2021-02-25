using System.Collections.Generic;
using MonoBehaviours.EventListeners;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "new game object event", menuName = "AATools/Events/SceneEvent")]
    public class SceneEvent : ScriptableObject
    {
        private readonly List<SceneEventListener> _listeners = new List<SceneEventListener>();

        public void Broadcast()
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast();
        }

        public void RegisterListener(SceneEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(SceneEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
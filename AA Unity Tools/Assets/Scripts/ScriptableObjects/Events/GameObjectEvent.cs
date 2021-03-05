using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "new game object event", menuName = "AATools/Events/GameObjectEvent")]
    public class GameObjectEvent : ScriptableObject
    {
        private readonly List<IGameObjectEventListener<GameObject>> _listeners = new List<IGameObjectEventListener<GameObject>>();

        public void Broadcast(GameObject go)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventBroadcast(go);
        }

        public void RegisterListener(IGameObjectEventListener<GameObject> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IGameObjectEventListener<GameObject> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}
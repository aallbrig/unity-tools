using System.Collections.Generic;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class BroadcastGameEvents : MonoBehaviour
    {
        public List<GameEvent> gameEvents = new List<GameEvent>();

        public void Broadcast() => gameEvents.ForEach(gameEvent => gameEvent.Broadcast());
    }
}
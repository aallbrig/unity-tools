using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class GameEventOnDisableProducer : MonoBehaviour, IEventProducer
    {
        public List<GameEvent> gameEvents = new List<GameEvent>();

        public void OnDisable() => ProduceEvents();
        public void ProduceEvents() => gameEvents.ForEach(gameEvent => gameEvent.Broadcast());
    }
}
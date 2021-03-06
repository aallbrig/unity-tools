﻿using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class BroadcastGameEvents : MonoBehaviour, IEventProducer
    {
        public List<GameEvent> gameEvents = new List<GameEvent>();
        public void ProduceEvents() => gameEvents.ForEach(gameEvent => gameEvent.Broadcast());

        public void Broadcast() => ProduceEvents();
    }
}
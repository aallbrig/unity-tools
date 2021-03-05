using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class SceneEventOnDisableProducer : MonoBehaviour, IEventProducer
    {
        public List<SceneEvent> sceneEvents = new List<SceneEvent>();

        public void OnDisable() => ProduceEvents();
        public void ProduceEvents() => sceneEvents.ForEach(sceneEvent => sceneEvent.Broadcast());
    }
}
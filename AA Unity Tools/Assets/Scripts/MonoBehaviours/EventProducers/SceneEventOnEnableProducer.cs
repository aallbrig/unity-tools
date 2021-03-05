using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class SceneEventOnEnableProducer : MonoBehaviour, IEventProducer
    {
        public List<SceneEvent> sceneEvents = new List<SceneEvent>();

        public void OnEnable() => ProduceEvents();
        public void ProduceEvents() => sceneEvents.ForEach(sceneEvent => sceneEvent.Broadcast());
    }
}
using System.Collections.Generic;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class SceneEventOnDisableProducer : MonoBehaviour
    {
        public List<SceneEvent> sceneEvents;

        private void OnDisable() => sceneEvents.ForEach(sceneEvent => sceneEvent.Broadcast());
    }
}
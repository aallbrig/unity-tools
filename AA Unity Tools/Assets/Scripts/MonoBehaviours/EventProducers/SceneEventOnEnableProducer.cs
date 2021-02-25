using System.Collections.Generic;
using ScriptableObjects.Events;
using UnityEngine;

namespace MonoBehaviours.EventProducers
{
    public class SceneEventOnEnableProducer : MonoBehaviour
    {
        public List<SceneEvent> sceneEvents;

        private void OnEnable() => sceneEvents.ForEach(sceneEvent => sceneEvent.Broadcast());
    }
}
using Interfaces;
using ScriptableObjects.Events;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM.Actions
{
    [CreateAssetMenu(fileName = "new broadcast game event", menuName = "AATools/ScriptableObjects/GameState/Actions/BroadcastGameEvent",
        order = 0)]
    public class BroadcastGameEvent : Action
    {
        public GameEvent gameEvent;
        public override void Act(IFiniteStateMachineContext<State> context) => gameEvent.Broadcast();
    }
}
﻿using MonoBehaviours.StateMachines;
using ScriptableObjects.Events;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM.Actions
{
    [CreateAssetMenu(fileName = "new broadcast game event", menuName = "AATools/GameState/Actions/BroadcastGameEvent",
        order = 0)]
    public class BroadcastGameEvent : Action
    {
        public GameEvent gameEvent;
        public override void Act(GamePlayCoreContext context) => gameEvent.Broadcast();
    }
}
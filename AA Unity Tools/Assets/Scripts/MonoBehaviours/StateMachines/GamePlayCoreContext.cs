﻿using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;
using UnityEngine;

namespace MonoBehaviours.StateMachines
{
    public class GamePlayCoreContext : MonoBehaviour
    {
        [Header("Finite State Machine")] public State currentState;

        private void Start() => currentState.StartState(this);

        private void Update() => currentState.UpdateState(this);

        public void TransitionToState(State nextState)
        {
            currentState.LeaveState(this);
            currentState = nextState;
            currentState.StartState(this);
        }
    }
}
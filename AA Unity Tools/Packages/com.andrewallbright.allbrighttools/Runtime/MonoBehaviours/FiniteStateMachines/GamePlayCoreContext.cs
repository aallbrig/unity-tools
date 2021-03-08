using Interfaces;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;
using UnityEngine;

namespace MonoBehaviours.FiniteStateMachines
{
    public class GamePlayCoreContext : MonoBehaviour, IFiniteStateMachineContext<State>
    {
        // Current state can be set from Unity Editor
        [Header("Finite State Machine")] public State currentState;

        private void Start() => CurrentState.StartState(this);

        private void Update() => CurrentState.UpdateState(this);

        public State CurrentState
        {
            get => currentState; // TODO: Check for null and create an initial state?
            set => currentState = value;
        }

        public void TransitionToState(State nextState)
        {
            CurrentState.LeaveState(this);
            CurrentState = nextState;
            CurrentState.StartState(this);
        }
    }
}
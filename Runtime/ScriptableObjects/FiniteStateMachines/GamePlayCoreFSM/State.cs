using System.Collections.Generic;
using Interfaces;
using Pocos.FiniteStateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    [CreateAssetMenu(fileName = "new game state", menuName = "AATools/ScriptableObjects/GameState/State", order = 0)]
    public class State : ScriptableObject, IState
    {
        [Header("On Start")] public List<Action> startActions = new List<Action>();
        [Header("Every Update")] public List<Action> updateActions = new List<Action>();
        [Header("On Leave")] public List<Action> leaveActions = new List<Action>();
        public readonly List<Transition<State, Decision>> transitions = new List<Transition<State, Decision>>();

        public void StartState(IFiniteStateMachineContext<State> context) =>
            startActions.ForEach(action => action.Act(context));

        public void UpdateState(IFiniteStateMachineContext<State> context)
        {
            updateActions.ForEach(action => action.Act(context));
            CheckTransitions(context);
        }

        public void LeaveState(IFiniteStateMachineContext<State> context) =>
            leaveActions.ForEach(action => action.Act(context));

        private void CheckTransitions(IFiniteStateMachineContext<State> context) => transitions.ForEach(transition =>
        {
            if (transition.decision.Decide(context))
                context.TransitionToState(transition.trueState);
        });
    }
}
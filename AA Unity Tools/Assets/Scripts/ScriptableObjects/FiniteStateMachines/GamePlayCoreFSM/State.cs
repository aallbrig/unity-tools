using System.Collections.Generic;
using MonoBehaviours.StateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    [CreateAssetMenu(fileName = "new game state", menuName = "AATools/GameState/State", order = 0)]
    public class State : ScriptableObject
    {
        [Header("On Start")] public List<Action> startActions;
        [Header("Every Update")] public List<Action> updateActions;
        public List<Transition> transitions;
        [Header("On Leave")] public List<Action> leaveActions;

        public void StartState(GamePlayCoreContext context) => startActions.ForEach(action => action.Act(context));

        public void UpdateState(GamePlayCoreContext context)
        {
            updateActions.ForEach(action => action.Act(context));
            CheckTransitions(context);
        }

        public void LeaveState(GamePlayCoreContext context) => leaveActions.ForEach(action => action.Act(context));

        private void CheckTransitions(GamePlayCoreContext context) => transitions.ForEach(transition =>
        {
            if (transition.decision.Decide(context))
                context.TransitionToState(transition.trueState);
        });
    }
}
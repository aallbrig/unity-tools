using System.Collections.Generic;
using MonoBehaviours.Controllers;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState
{
	[CreateAssetMenu(fileName = "new game state", menuName = "AATools/GameState/State", order = 0)]
	public class State : ScriptableObject
	{
		[Header("On Start")] public List<Action> startActions;
		[Header("Every Update")] public List<Action> updateActions;
		public List<Transition> transitions;
		[Header("On Leave")] public List<Action> leaveActions;

		public void StartState(GameStateController controller) => startActions.ForEach(action => action.Act(controller));

		public void UpdateState(GameStateController controller)
		{
			updateActions.ForEach(action => action.Act(controller));
			CheckTransitions(controller);
		}

		public void LeaveState(GameStateController controller) => leaveActions.ForEach(action => action.Act(controller));

		private void CheckTransitions(GameStateController controller) => transitions.ForEach(transition =>
		{
			if (transition.decision.Decide(controller))
				controller.TransitionToState(transition.trueState);
		});
	}
}
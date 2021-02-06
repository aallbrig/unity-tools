using MonoBehaviours.Controllers;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState.Decisions
{
	[CreateAssetMenu(fileName = "new Keyboard Button Down", menuName = "AATools/GameState/Decisions/KeyboardKeyDown",
		order = 0)]
	public class KeyboardKeyDown : Decision
	{
		public KeyCode keyCode;

		public override bool Decide(GameStateController controller) => Input.GetKeyDown(keyCode);
	}
}
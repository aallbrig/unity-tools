using Interfaces;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM.Decisions
{
    [CreateAssetMenu(fileName = "new Keyboard Button Down", menuName = "AATools/ScriptableObjects/GameState/Decisions/KeyboardKeyDown",
        order = 0)]
    public class KeyboardKeyDown : Decision
    {
        public KeyCode keyCode;

        public override bool Decide(IFiniteStateMachineContext<State> context) => Input.GetKeyDown(keyCode);
    }
}
using MonoBehaviours.StateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM.Decisions
{
    [CreateAssetMenu(fileName = "new Keyboard Button Down", menuName = "AATools/GameState/Decisions/KeyboardKeyDown",
        order = 0)]
    public class KeyboardKeyDown : Decision
    {
        public KeyCode keyCode;

        public override bool Decide(GamePlayCoreContext context) => Input.GetKeyDown(keyCode);
    }
}
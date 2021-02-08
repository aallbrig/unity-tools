using MonoBehaviours.StateMachines;
using ScriptableObjects.Refs;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState.Actions
{
    [CreateAssetMenu(fileName = "new SetBoolVar action", menuName = "AATools/GameState/Actions/SetBoolVar", order = 0)]
    public class SetBoolVar : Action
    {
        public BoolVar targetBoolVar;
        public BoolRef boolRef;

        public override void Act(GameStateContext context) => targetBoolVar.value = boolRef.Value;
    }
}
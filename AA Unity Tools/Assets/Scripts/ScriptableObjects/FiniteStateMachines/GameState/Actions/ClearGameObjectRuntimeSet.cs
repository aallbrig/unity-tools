using MonoBehaviours.StateMachines;
using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState.Actions
{
    [CreateAssetMenu(fileName = "new clear runtime set", menuName = "AATools/GameState/Actions/ClearGameObjectRuntimeSet",
        order = 0)]
    public class ClearGameObjectRuntimeSet : Action
    {
        public GameObjectRuntimeSet gameObjectRuntimeSet;
        public override void Act(GameStateContext context) => gameObjectRuntimeSet.list.Clear();
    }
}
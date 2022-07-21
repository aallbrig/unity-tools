using Interfaces;
using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM.Actions
{
    [CreateAssetMenu(fileName = "new clear runtime set", menuName = "AATools/ScriptableObjects/GameState/Actions/ClearGameObjectRuntimeSet",
        order = 0)]
    public class ClearGameObjectRuntimeSet : Action
    {
        public GameObjectRuntimeSet gameObjectRuntimeSet;
        public override void Act(IFiniteStateMachineContext<State> context) => gameObjectRuntimeSet.list.Clear();
    }
}
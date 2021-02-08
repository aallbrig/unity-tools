using MonoBehaviours.StateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(GameStateContext context);
    }
}
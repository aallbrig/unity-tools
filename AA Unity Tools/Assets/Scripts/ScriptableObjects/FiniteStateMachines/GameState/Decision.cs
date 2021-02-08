using MonoBehaviours.StateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(GameStateContext context);
    }
}
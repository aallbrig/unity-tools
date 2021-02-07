using MonoBehaviours.Controllers;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(GameStateController controller);
    }
}
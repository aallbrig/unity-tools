using MonoBehaviours.Controllers;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GameState
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(GameStateController controller);
    }
}
using MonoBehaviours.StateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(GamePlayCoreContext context);
    }
}
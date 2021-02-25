using MonoBehaviours.StateMachines;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(GamePlayCoreContext context);
    }
}
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(IFiniteStateMachineContext<State> context);
    }
}
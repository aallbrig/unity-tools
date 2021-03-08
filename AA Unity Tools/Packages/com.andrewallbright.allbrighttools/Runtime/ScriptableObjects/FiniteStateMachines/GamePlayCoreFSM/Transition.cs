using System;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    [Serializable]
    public class Transition
    {
        public Decision decision;
        public State trueState;
    }
}
using System;

namespace ScriptableObjects.FiniteStateMachines.GameState
{
    [Serializable]
    public class Transition
    {
        public Decision decision;
        public State trueState;
    }
}
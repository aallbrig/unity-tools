using System;

namespace Pocos.FiniteStateMachines
{
    [Serializable]
    public class Transition<TState, TDecision>
    {
        public TState trueState;
        public TDecision decision;
    }
}
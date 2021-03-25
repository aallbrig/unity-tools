using Interfaces;
using NSubstitute;
using NUnit.Framework;
using Pocos.FiniteStateMachines;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;

namespace Tests.Runtime.EditMode.POCOS.FiniteStateMachines
{
    public class TransitionTests
    {
        [Test]
        public void Transition_Contains_ADecision()
        {
            var decision = Substitute.For<Decision>();
            var transition = new Transition<State, Decision>();

            transition.decision = decision;

            Assert.NotNull(transition.decision);
        }

        [Test]
        public void Transition_Contains_ATrueState()
        {
            var state = Substitute.For<State>();
            var transition = new Transition<State, Decision>();

            transition.trueState = state;

            Assert.NotNull(transition.trueState);
        }

        [Test]
        // This is an instructional test IMO
        public void Transition_ContainsATrueState_WhenADecisionReturnsTrue()
        {
            var state = Substitute.For<State>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();
            var decision = Substitute.For<Decision>();
            var transition = new Transition<State, Decision>();
            decision.Decide(context).Returns(true);

            transition.trueState = state;
            transition.decision = decision;

            Assert.True(transition.decision.Decide(context));
            Assert.NotNull(transition.trueState);
        }
    }
}
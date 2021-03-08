using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;
using UnityEngine;

namespace Tests.Runtime.EditMode.ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public class StateTests
    {
        [Test] public void ScriptableObject_Asset_Creatable() => ScriptableObject.CreateInstance<State>();

        [Test]
        public void State_StartActions_CalledOnStartState()
        {
            var state = ScriptableObject.CreateInstance<State>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();
            var action = Substitute.For<Action>();
            state.startActions.Add(action);

            state.StartState(context);

            action.Received().Act(context);
        }

        [Test]
        public void State_UpdateActions_CalledOnUpdateState()
        {
            var state = ScriptableObject.CreateInstance<State>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();
            var action = Substitute.For<Action>();
            state.updateActions.Add(action);

            state.UpdateState(context);

            action.Received().Act(context);
        }

        [Test]
        public void State_TransitionDecision_CalledOnUpdateState()
        {
            var state = ScriptableObject.CreateInstance<State>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();
            var decision = Substitute.For<Decision>();
            var transition = new Transition {decision = decision};
            state.transitions.Add(transition);

            state.UpdateState(context);

            decision.Received().Decide(context);
        }

        [Test]
        public void State_TransitionsToNewState_WhenTransitionDecisionTrue()
        {
            var state = ScriptableObject.CreateInstance<State>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();
            var decision = Substitute.For<Decision>();
            decision.Decide(context).Returns(true);
            var trueState = ScriptableObject.CreateInstance<State>();
            var transition = new Transition {decision = decision, trueState = trueState};
            state.transitions.Add(transition);

            state.UpdateState(context);

            context.Received().TransitionToState(trueState);
        }
    }
}
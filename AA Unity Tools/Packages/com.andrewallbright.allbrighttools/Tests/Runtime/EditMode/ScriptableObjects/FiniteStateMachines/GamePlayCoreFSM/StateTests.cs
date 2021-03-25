using Interfaces;
using NSubstitute;
using NUnit.Framework;
using Pocos.FiniteStateMachines;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;
using UnityEngine;

namespace Tests.Runtime.EditMode.ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public class StateTests
    {
        public class DecisionAliasTrue : Decision
        {
            public override bool Decide(IFiniteStateMachineContext<State> context) => true;
        }

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
            var transition = new Transition<State, Decision> {decision = decision};
            state.transitions.Add(transition);

            state.UpdateState(context);

            decision.Received().Decide(context);
        }

        [Test]
        public void State_TransitionsToNewState_WhenTransitionDecisionTrue()
        {
            var state = ScriptableObject.CreateInstance<State>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();
            var trueState = ScriptableObject.CreateInstance<State>();
            var transition = new Transition<State, Decision>
            {
                decision = ScriptableObject.CreateInstance<DecisionAliasTrue>(),
                trueState = trueState
            };

            state.transitions.Add(transition);

            state.UpdateState(context);

            context.Received().TransitionToState(trueState);
        }
    }
}
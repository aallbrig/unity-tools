using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public class ActionAlias : Action
    {
        public override void Act(IFiniteStateMachineContext<State> context) {}
    }

    public class ActionTests
    {
        [Test]
        public void Action_AssetCanBe_CreatedFromAnImplementingClass() =>
            Assert.NotNull(ScriptableObject.CreateInstance<ActionAlias>());

        [Test]
        public void Action_Can_Act()
        {
            var action = Substitute.For<Action>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();

            action.Act(context);

            action.Received().Act(context);
        }
    }
}
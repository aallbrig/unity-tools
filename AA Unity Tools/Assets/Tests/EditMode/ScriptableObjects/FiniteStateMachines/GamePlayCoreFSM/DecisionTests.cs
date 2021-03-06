using System;
using Interfaces;
using NSubstitute;
using NUnit.Framework;
using ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM;
using UnityEngine;

namespace Tests.EditMode.ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public class DecisionAlias : Decision
    {
        public override bool Decide(IFiniteStateMachineContext<State> context) => throw new NotImplementedException();
    }

    public class DecisionTests
    {
        [Test]
        public void Decision_AssetCanBe_CreatedFromAnImplementingClass() =>
            Assert.NotNull(ScriptableObject.CreateInstance<DecisionAlias>());

        [Test]
        public void Decision_DecidesByReturning_Bool()
        {
            var decision = Substitute.For<Decision>();
            var context = Substitute.For<IFiniteStateMachineContext<State>>();

            decision.Decide(context);

            decision.Received().Decide(context);
        }
    }
}
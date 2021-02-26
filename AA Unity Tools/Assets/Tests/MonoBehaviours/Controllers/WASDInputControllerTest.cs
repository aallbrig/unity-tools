using Interfaces;
using MonoBehaviours.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.MonoBehaviours.Controllers
{
    public class WASDInputControllerTest
    {
        [Test]
        public void WASDInputController_ScriptExists()
        {
            var input = Substitute.For<IInput>();
            input.GetAxis("Vertical").Returns(-1);

            Assert.AreEqual(-1, input.GetAxis("Vertical"));
        }

        [Test]
        public void WASDInputController_ScriptCanBeAttachedToGameObject()
        {
            var script = new GameObject().AddComponent<WASDInputController>();

            Assert.NotNull(script);
        }

        [Test]
        public void WASDInputController_MoveFunction_ReceivesVerticalAndHorizontalInput_Zeros()
        {
            // Arrange
            var gameObject = new GameObject();
            var script = gameObject.AddComponent<WASDInputController>();

            var input = Substitute.For<IInput>();
            // Expected input ranges from -1 to 1
            // TODO: test table to exercise every value (since there aren't that many)
            var randomVertical = Random.Range(-1, 1);
            var randomHorizontal = Random.Range(-1, 1);
            input.GetAxis("Vertical").Returns(randomVertical);
            input.GetAxis("Horizontal").Returns(randomHorizontal);

            var move = Substitute.For<IMoveable>();
            script.Move = move;
            script.Input = input;

            // Act
            script.Update();

            // Assert
            move.Received().Move(new Vector3(randomHorizontal, 0, randomVertical));
        }
    }
}
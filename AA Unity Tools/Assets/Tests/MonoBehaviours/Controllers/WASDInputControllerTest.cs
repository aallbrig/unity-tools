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
        public void WASDInputController_ScriptCanBeAttachedToGameObject()
        {
            var script = new GameObject().AddComponent<WASDInputController>();

            Assert.NotNull(script);
        }

        [Test]
        public void WASDInputController_MoveFunction_ReceivesVerticalAndHorizontalInput()
        {
            // Arrange
            var gameObject = new GameObject();
            var script = gameObject.AddComponent<WASDInputController>();

            var verticalValue = Random.Range(1, 1337);
            var horizontalValue = Random.Range(1, 1337);

            var input = Substitute.For<IInput>();
            input.GetAxis("Vertical").Returns(verticalValue);
            input.GetAxis("Horizontal").Returns(horizontalValue);

            var move = Substitute.For<IMoveable>();
            script.Move = move;
            script.Input = input;

            // Act
            script.Update();

            // Assert
            move.Received().Move(new Vector3(horizontalValue, 0, verticalValue));
        }
    }
}
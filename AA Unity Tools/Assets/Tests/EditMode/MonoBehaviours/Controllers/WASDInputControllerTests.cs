using Interfaces;
using MonoBehaviours.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class WASDInputControllerTests
    {
        [Test]
        public void Script_Exists() =>
            Assert.NotNull(new GameObject().AddComponent<WASDInputController>());

        [Test]
        public void WASDInputController_MoveFunction_ReceivesVerticalAndHorizontalInput()
        {
            // Arrange
            var input = Substitute.For<IInput>();
            var move = Substitute.For<IMoveable>();
            var script = new GameObject().AddComponent<WASDInputController>();
            var verticalValue = Random.Range(1, 1337);
            var horizontalValue = Random.Range(1, 1337);

            input.GetAxis("Vertical").Returns(verticalValue);
            input.GetAxis("Horizontal").Returns(horizontalValue);
            script.Move = move;
            script.Input = input;

            // Act
            script.Update();

            // Assert
            move.Received().Move(new Vector3(horizontalValue, 0, verticalValue));
        }
    }
}
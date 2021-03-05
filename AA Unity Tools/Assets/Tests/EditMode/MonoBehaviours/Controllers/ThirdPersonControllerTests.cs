using Interfaces;
using MonoBehaviours.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MonoBehaviours.Controllers
{
    public class ThirdPersonControllerTests
    {
        [Test]
        public void Script_Exists() =>
            Assert.NotNull(new GameObject().AddComponent<ThirdPersonController>());

        [Test]
        public void ThirdPersonController_MoveInterface_ReceivesVerticalInput()
        {
            // Arrange
            var gameObject = new GameObject();
            var script = gameObject.AddComponent<ThirdPersonController>();
            var input = Substitute.For<IInput>();
            var move = Substitute.For<IMoveable>();
            var verticalValue = 1337;

            input.GetAxis("Vertical").Returns(verticalValue);
            script.Move = move;
            script.Input = input;

            // Act
            script.Update();

            // Assert
            move.Received().Move(new Vector3(0, 0, verticalValue));
        }

        [Test]
        public void ThirdPersonController_RotateInterface_ReceivesHorizontalInput()
        {
            // Arrange
            var gameObject = new GameObject();
            var script = gameObject.AddComponent<ThirdPersonController>();
            var input = Substitute.For<IInput>();
            var horizontalInput = 1337;
            var rotate = Substitute.For<IRotateable>();

            input.GetAxis("Horizontal").Returns(horizontalInput);
            script.Rotate = rotate;
            script.Input = input;

            // Act
            script.Update();

            // Assert
            rotate.Received().Rotate(new Vector3(0, horizontalInput, 0));
        }
    }
}
using Interfaces;
using MonoBehaviours.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.MonoBehaviours.Controllers
{
    public class ThirdPersonControllerTests
    {
        [Test]
        public void ThirdPersonController_ScriptCanBeAttachedToGameObject()
        {
            var script = new GameObject().AddComponent<ThirdPersonController>();
            Assert.NotNull(script);
        }

        [Test]
        public void ThirdPersonController_MoveInterface_ReceivesVerticalInput()
        {
            // Arrange
            var gameObject = new GameObject();
            var script = gameObject.AddComponent<ThirdPersonController>();

            var input = Substitute.For<IInput>();
            var verticalValue = 1337;
            input.GetAxis("Vertical").Returns(verticalValue);

            var move = Substitute.For<IMoveable>();
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
            input.GetAxis("Horizontal").Returns(horizontalInput);

            var rotate = Substitute.For<IRotateable>();
            script.Rotate = rotate;
            script.Input = input;

            // Act
            script.Update();

            // Assert
            rotate.Received().Rotate(new Vector3(0, horizontalInput, 0));
        }
    }
}
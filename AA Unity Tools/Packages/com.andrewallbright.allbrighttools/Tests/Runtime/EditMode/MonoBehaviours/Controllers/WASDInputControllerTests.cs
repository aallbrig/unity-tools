using Interfaces;
using MonoBehaviours.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Runtime.EditMode.MonoBehaviours.Controllers
{
    public class WASDInputControllerTests
    {
        [Test]
        public void WASDInputController_MoveFunction_ReceivesVerticalAndHorizontalInput()
        {
            // Arrange
            var input = Substitute.For<IInput>();
            var move = Substitute.For<IMoveable>();
            var script = new GameObject().AddComponent<WASDInputController>();
            var verticalValue = Random.Range(0f, 1f);
            var horizontalValue = Random.Range(0f, 1f);

            input.GetAxis("Vertical").Returns(verticalValue);
            input.GetAxis("Horizontal").Returns(horizontalValue);
            script.Move = move;
            script.Input = input;
            script.ForwardTransform = new GameObject().transform;

            // Act
            script.HandleMovementInput();

            // Assert
            move.Received().Move(new Vector3(horizontalValue, 0, verticalValue));
        }

        [Test]
        public void WASDInputController_NoRotationApplied_WhenRotationAngleIsZero()
        {
            // Arrange
            var script = new GameObject().AddComponent<WASDInputController>();
            var input = Substitute.For<IInput>();
            var move = Substitute.For<IMoveable>();

            input.GetAxis("Vertical").Returns(1);
            input.GetAxis("Horizontal").Returns(0);
            script.Move = move;
            script.Input = input;
            script.ForwardTransform = new GameObject().transform;
            // Act
            script.HandleMovementInput();

            // Assert
            move.Received().Move(new Vector3(0, 0, 1));
        }

        [Test]
        public void WASDInputController_RotationApplied_WhenRotationAngleIsNonZero()
        {
            // Arrange
            var script = new GameObject().AddComponent<WASDInputController>();
            var input = Substitute.For<IInput>();
            var move = Substitute.For<IMoveable>();
            var relativeToGameObject = new GameObject();

            relativeToGameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            input.GetAxis("Vertical").Returns(1);
            input.GetAxis("Horizontal").Returns(0);
            script.Move = move;
            script.Input = input;
            script.ForwardTransform = relativeToGameObject.transform;

            // Act
            script.HandleMovementInput();

            // Assert
            move.Received().Move(new Vector3(0, 0, 1));
        }
    }
}
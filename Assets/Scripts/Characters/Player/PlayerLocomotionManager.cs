using InputHandler;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {

        private void FixedUpdate()
        {
            if (_characterController == null)
                return;

            SetMoveDirection();

            if (_characterMoveDirection.magnitude < 0.1f)
                return;

            HandleMoveLocomotion(_characterMoveDirection);
            HandleRotationLocomotion(_characterMoveDirection);
        }

        private void HandleMoveLocomotion(Vector3 direction)
        {
            _characterController.Move(_characterSpeed * Time.deltaTime * _characterMoveDirection);
        }

        private void SetMoveDirection()
        {
            _characterMoveDirection.x = InputManager.Instance.GetMovementDirection.y;
            _characterMoveDirection.z = -InputManager.Instance.GetMovementDirection.x;

        }

        private void HandleRotationLocomotion(Vector3 direction)
        {
            Quaternion targetAngle = Quaternion.LookRotation(direction);

            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * _rotationSpeed);

            transform.rotation = targetRotation;
        }
    }
}

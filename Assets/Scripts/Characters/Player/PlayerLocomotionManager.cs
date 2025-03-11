using InputHandler;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        private void FixedUpdate()
        {
            if(_characterController == null)
                return;

            SetMoveDirection();

            if(_characterMoveDirection.magnitude < 0.1f)
                return;

            HandleLocomotion(_characterMoveDirection);
        }

        private void HandleLocomotion(Vector2 direction)
        {
            Vector3 worldDirection = new Vector3(direction.x, 0, direction.y);
            _characterController.Move(_characterSpeed * Time.deltaTime * worldDirection);
        }

        private void SetMoveDirection()
        {
            _characterMoveDirection.x = InputManager.Instance.GetMovementDirection.y;
            _characterMoveDirection.y = -InputManager.Instance.GetMovementDirection.x;
        }
    }
}

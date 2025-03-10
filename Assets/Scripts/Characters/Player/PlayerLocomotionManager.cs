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

            _characterMoveDirection = InputManager.Instance.GetMovementDirection;

            if(_characterMoveDirection.magnitude < 0.1f)
                return;

            HandleLocomotion(_characterMoveDirection);
        }

        private void HandleLocomotion(Vector2 direction)
        {
            Vector3 worldDirection = new Vector3(direction.x, 0, direction.y);
            _characterController.Move(worldDirection * _characterSpeed * Time.deltaTime);
        }
    }
}

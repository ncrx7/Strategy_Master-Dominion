using InputHandler;
using UnityEngine;
using Zenject;

namespace Characters.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager<CharacterController>
    {
        [SerializeField] protected CharacterController _characterController;

        private void FixedUpdate()
        {
            if (_characterController == null)
                return;

            SetLocomotionDirection();

            if (_characterMoveDirection.magnitude < 0.1f)
                return;

            Move();
            Rotate();
        }

        public override void Move()
        {
            MoveService.Move(_characterController, _characterMoveDirection, _characterSpeed);
        }

        public override void Rotate()
        {
            Quaternion targetAngle = Quaternion.LookRotation(_characterMoveDirection);

            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * _rotationSpeed);

            transform.rotation = targetRotation;
        }

        protected override void SetLocomotionDirection()
        {
            _characterMoveDirection.x = InputManager.Instance.GetMovementDirection.y;
            _characterMoveDirection.z = -InputManager.Instance.GetMovementDirection.x;
        }
    }
}

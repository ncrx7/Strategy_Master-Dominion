using InputHandler;
using UnityEngine;
using Zenject;

namespace Characters.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager<CharacterController>
    {
        [SerializeField] protected CharacterController _characterController;

        private void OnEnable()
        {
            InputManager.Instance.OnMovePerformed += OnCharacterMoveStart;
            InputManager.Instance.OnMoveCancelled += OnCharacterMoveCancel;
        }

        private void OnDisable()
        {
            InputManager.Instance.OnMovePerformed -= OnCharacterMoveStart;
            InputManager.Instance.OnMoveCancelled -= OnCharacterMoveCancel;
        }

        private void FixedUpdate()
        {
            if (_characterController == null)
                return;

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

        protected override void OnCharacterMoveStart(Vector2 directionResponse)
        {
            _characterMoveDirection.x = directionResponse.y;
            _characterMoveDirection.z = -directionResponse.x;
        }

        protected override void OnCharacterMoveCancel()
        {
            _characterMoveDirection = Vector3.zero;
        }
    }
}

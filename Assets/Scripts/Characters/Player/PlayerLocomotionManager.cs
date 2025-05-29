using Characters.Services.Move;
using InputHandler;
using StateMachine.Player;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Characters.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager<CharacterController>
    {
        [SerializeField] protected CharacterController _characterController;

        [Inject] private InputManager _inputManager;


        private void OnEnable()
        {
            _inputManager.OnMovePerformed += OnCharacterMoveStart;
            _inputManager.OnMoveCancelled += OnCharacterMoveCancel;
        }

        private void OnDisable()
        {
            _inputManager.OnMovePerformed -= OnCharacterMoveStart;
            _inputManager.OnMoveCancelled -= OnCharacterMoveCancel;
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

            _characterManager.GetCharacterStateMachine.ChangeState<PlayerMoveState>();
        }

        protected override void OnCharacterMoveCancel()
        {
            _characterMoveDirection = Vector3.zero;

            _characterManager.GetCharacterStateMachine.ChangeState<PlayerIdleState>();
        }

        public InputManager GetInputManager => _inputManager;
    }
}

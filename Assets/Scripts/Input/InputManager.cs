using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtils.BaseClasses;

namespace InputHandler
{
    public class InputManager : SingletonBehavior<InputManager>
    {
        private InputSystemActions _inputControls;

        [Header("Player Movement fields")]
        [SerializeField] private Vector2 _movementInput;
        public float MoveAmount { get; private set; }

        private void OnEnable()
        {
            if (_inputControls == null)
            {
                _inputControls = new InputSystemActions();

                _inputControls.Player.Move.performed += HandleLocomotionInputData;
                _inputControls.Player.Move.canceled += ResetLocomotionInputData;
            }

            _inputControls.Enable();
        }

        private void OnDisable()
        {
            _inputControls.Player.Move.performed -= HandleLocomotionInputData;
            _inputControls.Player.Move.canceled -= ResetLocomotionInputData;
        }

        private void HandleLocomotionInputData(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<Vector2>();

            MoveAmount = Mathf.Clamp01(Mathf.Abs(_movementInput.y) + Mathf.Abs(_movementInput.x));
            //Debug.Log("move amount: " + MoveAmount);

            if (MoveAmount <= 0.5 && MoveAmount > 0)
            {
                MoveAmount = 0.5f;
            }
            else if (MoveAmount > 0.5 && MoveAmount <= 1)
            {
                MoveAmount = 1;
            }
            //EventSystem.MoveCharacterOnGround?.Invoke(_movementInput);
        }

        private void ResetLocomotionInputData(InputAction.CallbackContext context)
        {
            _movementInput = Vector2.zero;
        }

        public Vector2 GetMovementDirection => _movementInput;
    }
}

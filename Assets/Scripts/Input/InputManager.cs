using System;
using EventChanells;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtils.BaseClasses;
using Zenject;

namespace InputHandler
{
    public class InputManager : MonoBehaviour
    {
        private InputSystemActions _inputControls;

        [Header("Player Movement fields")]
        [SerializeField] private Vector2 _movementInput;
        public float MoveAmount;

        private SignalBus _signalBus;

        public Action<Vector2> OnMovePerformed;
        public Action OnMoveCancelled;

        [Inject]
        private void InjectDependencies(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            if (_inputControls == null)
            {
                _inputControls = new InputSystemActions();

                _inputControls.Player.Move.performed += HandleLocomotionInputData;
                _inputControls.Player.Move.canceled += ResetLocomotionInputData;
            }

            _inputControls.Enable();

            _signalBus.Subscribe<CinematicStartedSignal>(DisableInput);
            _signalBus.Subscribe<CinematicEndSignal>(EnableInput);
        }

        private void OnDisable()
        {
            _inputControls.Player.Move.performed -= HandleLocomotionInputData;
            _inputControls.Player.Move.canceled -= ResetLocomotionInputData;

            _signalBus.Unsubscribe<CinematicStartedSignal>(DisableInput);
            _signalBus.Unsubscribe<CinematicEndSignal>(EnableInput);
        }

        public void EnableInput()
        {
            _inputControls.Enable();
        }
        public void DisableInput()
        {
            _inputControls.Disable();
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
         
            OnMovePerformed?.Invoke(_movementInput);
        }

        private void ResetLocomotionInputData(InputAction.CallbackContext context)
        {
            _movementInput = Vector2.zero;
            MoveAmount = 0;
            OnMoveCancelled?.Invoke();
        }

        public Vector2 GetMovementDirection => _movementInput;
    }
}

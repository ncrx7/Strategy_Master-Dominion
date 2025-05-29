using Characters;
using Characters.Player;
using InputHandler;
using UnityEngine;
using UnityUtils.GenericDesignPatterns.StateMachine;
using Zenject;

namespace StateMachine.Player
{
    public class PlayerIdleState : IState
    {
        private PlayerManager _playerManager;
        private InputManager _inputManager;

        public PlayerIdleState(PlayerManager playerManager)
        {
            _playerManager = playerManager;

            if (_playerManager.GetCharacterLocomotionManager is PlayerLocomotionManager playerLocomotionManager)
            {

                _inputManager = playerLocomotionManager.GetInputManager;
            }

        }

        public void OnEnterState()
        {
            _playerManager.GetCharacterAnimationManager.UpdateAnimatorParameter(AnimatorValueType.FLOAT, "Vertical", _inputManager.MoveAmount, false, 0.5f);
            Debug.LogWarning("Entered idle state");
        }

        public void OnExitState()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}

using Characters.Player;
using UnityEngine;
using UnityUtils.GenericDesignPatterns.StateMachine;

namespace StateMachine.Player
{
    public class PlayerMoveState : IState
    {
        private PlayerManager _playerManager;

        public PlayerMoveState(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public void OnEnterState()
        {

        }

        public void OnExitState()
        {
            
        }

        public void Tick()
        {
            _playerManager.GetCharacterLocomotionManager.Move();
            _playerManager.GetCharacterLocomotionManager.Rotate();
        }
    }
}

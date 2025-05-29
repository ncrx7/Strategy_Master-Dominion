using StateMachine.Player;
using UnityEngine;
using UnityUtils.GenericDesignPatterns.StateMachine;

namespace Characters.Player
{
    public class PlayerManager : CharacterManager<CharacterController>
    {
        private void FixedUpdate()
        {
            _stateMachine.TickState();
        }

        protected override void SetStateMachine()
        {
            base.SetStateMachine();

            var idleState = new PlayerIdleState(this);
            var moveState = new PlayerMoveState(this);

            _stateMachine.AddState(idleState);
            _stateMachine.AddState(moveState);

            _stateMachine.SetInitialState<PlayerIdleState>();
        }      
    }
}

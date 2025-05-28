using UnityEngine;
using UnityUtils.GenericDesignPatterns.StateMachine;
using Zenject;

namespace Characters
{
    public class CharacterManager<T> : MonoBehaviour
    {
        protected CharacterLocomotionManager<T> _characterLocomotionManager;
        protected StateMachineController _stateMachine;

        protected virtual void Start()
        {
            SetStateMachine();
        }

        [Inject]
        private void InjectDependencies(CharacterLocomotionManager<T> characterLocomotionManager)
        {
            _characterLocomotionManager = characterLocomotionManager;
        }

        protected virtual void SetStateMachine()
        {
            _stateMachine = new StateMachineController();
        }

        public CharacterLocomotionManager<T> GetCharacterLocomotionManager => _characterLocomotionManager;
        public StateMachineController GetCharacterStateMachine => _stateMachine;
    }
}

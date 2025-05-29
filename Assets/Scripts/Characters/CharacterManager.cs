using UnityEngine;
using UnityUtils.GenericDesignPatterns.StateMachine;
using Zenject;

namespace Characters
{
    public class CharacterManager<T> : MonoBehaviour
    {
        protected CharacterLocomotionManager<T> _characterLocomotionManager;
        protected CharacterAnimationManager<T> _characterAnimationManager;


        protected StateMachineController _stateMachine;

        protected virtual void Start()
        {
            SetStateMachine();
        }

        [Inject]
        private void InjectDependencies(CharacterLocomotionManager<T> characterLocomotionManager, CharacterAnimationManager<T> characterAnimationManager)
        {
            _characterLocomotionManager = characterLocomotionManager;
            _characterAnimationManager = characterAnimationManager;
        }

        protected virtual void SetStateMachine()
        {
            _stateMachine = new StateMachineController();
        }

        public CharacterLocomotionManager<T> GetCharacterLocomotionManager => _characterLocomotionManager;
        public CharacterAnimationManager<T> GetCharacterAnimationManager => _characterAnimationManager; 
        public StateMachineController GetCharacterStateMachine => _stateMachine;
    }
}

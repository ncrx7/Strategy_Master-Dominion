using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterAnimationManager<T> : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        protected CharacterManager<T> _characterManager;

        [Inject]
        private void InjectDependencies(CharacterManager<T> characterManager)
        {
            _characterManager = characterManager;
        }

        public void UpdateAnimatorMovementParameters(float horizontalValue, float verticalValue)
        {
            //Classic assign
            _animator.SetFloat("Horizontal", horizontalValue, 0.1f, Time.deltaTime);
            _animator.SetFloat("Vertical", verticalValue, 0.1f, Time.deltaTime);
        }

        //TODO: UPDATE PARAMETER SERVICE
        public void UpdateAnimatorParameter(AnimatorValueType animatorValueType, string parameterName, float floatValue, bool boolValue)
        {
            switch (animatorValueType)
            {
                case AnimatorValueType.FLOAT:
                    _animator.SetFloat(parameterName, floatValue, 0.5f, Time.deltaTime);
                    break;
                case AnimatorValueType.BOOL:
                    _animator.SetBool(parameterName, boolValue);
                    break;
            }
        }

        public void PlayTargetAnimation(ulong id, string targetAnimation, bool isPerformingAction, bool canRotate = false, bool canMove = false, bool applyRootMotion = true)
        {
            //_characterManager.applyRootMotion = applyRootMotion;
            _animator.CrossFade(targetAnimation, 0.2f);
            //_characterManager.isPerformingAction = isPerformingAction;
            //_characterManager.canMove = canMove;
            //_characterManager.canRotate = canRotate;

        }
    }

    public enum AnimatorValueType
    {
        FLOAT,
        BOOL,
        INT
    }
}




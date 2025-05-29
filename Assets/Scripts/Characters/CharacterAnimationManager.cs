using Cysharp.Threading.Tasks;
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
        public void UpdateAnimatorParameter(AnimatorValueType animatorValueType, string parameterName, float floatValue, bool boolValue, float dampTime)
        {
            switch (animatorValueType)
            {
                case AnimatorValueType.FLOAT:
                    DampSettingFloat(parameterName, floatValue, dampTime).Forget();
                    break;
                case AnimatorValueType.BOOL:
                    _animator.SetBool(parameterName, boolValue);
                    break;
            }
        }

        public void PlayTargetAnimation(string targetAnimation, float dampTime, bool isPerformingAction, bool canRotate = false, bool canMove = false, bool applyRootMotion = true)
        {
            //_characterManager.applyRootMotion = applyRootMotion;
            _animator.CrossFade(targetAnimation, dampTime);
            //_characterManager.isPerformingAction = isPerformingAction;
            //_characterManager.canMove = canMove;
            //_characterManager.canRotate = canRotate;

        }

        private async UniTaskVoid DampSettingFloat(string parameterName, float targetValue, float duration)
        {
            float startValue = _animator.GetFloat(parameterName);
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                float newValue = Mathf.Lerp(startValue, targetValue, t);
    
                _animator.SetFloat(parameterName, newValue);

                await UniTask.Yield(PlayerLoopTiming.Update); 
            }

            _animator.SetFloat(parameterName, targetValue);
        }
    }

    public enum AnimatorValueType
    {
        FLOAT,
        BOOL,
        INT
    }
}




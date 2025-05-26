using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager<T> : MonoBehaviour
    {
        protected CharacterLocomotionManager<T> _characterLocomotionManager;

        [Inject]
        private void InjectDependencies(CharacterLocomotionManager<T> characterLocomotionManager)
        {
            _characterLocomotionManager = characterLocomotionManager;
        }
    }
}

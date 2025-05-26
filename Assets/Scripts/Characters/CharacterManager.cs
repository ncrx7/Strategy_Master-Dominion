using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        protected CharacterLocomotionManager _characterLocomotionManager;

        [Inject]
        private void InjectDependencies(CharacterLocomotionManager characterLocomotionManager)
        {
            _characterLocomotionManager = characterLocomotionManager;
        }
    }
}

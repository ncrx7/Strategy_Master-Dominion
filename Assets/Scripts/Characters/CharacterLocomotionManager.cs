using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Characters
{
    public class CharacterLocomotionManager : MonoBehaviour
    {
        protected CharacterManager _characterManager;

        [Header("References")]
        [SerializeField] protected CharacterController _characterController;

        [Header("Properties")]
        [SerializeField] protected float _characterSpeed;
        [SerializeField] protected Vector3 _characterMoveDirection;

        [SerializeField] protected float _rotationSpeed;

        [Inject]
        private void InjectDependencies(CharacterManager characterManager)
        {
            _characterManager = characterManager;
        }
    }
}

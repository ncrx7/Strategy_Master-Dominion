using Characters.Services.Move;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Characters
{
    public class CharacterLocomotionManager<T> : MonoBehaviour
    {
        protected CharacterManager<T> _characterManager;
        public IMoveService<T> MoveService;

        [Header("Properties")]
        [SerializeField] protected float _characterSpeed;
        [SerializeField] protected float _rotationSpeed;

        protected Vector3 _characterMoveDirection;


        [Inject]
        protected virtual void InjectDependencies(CharacterManager<T> characterManager, IMoveService<T> moveService)
        {
            _characterManager = characterManager;
            MoveService = moveService;
        }

        public virtual void Move() { }
        public virtual void Rotate() { }

        protected virtual void OnCharacterMoveStart(Vector2 directionResponse) { }
        protected virtual void OnCharacterMoveCancel() { }

    }
}

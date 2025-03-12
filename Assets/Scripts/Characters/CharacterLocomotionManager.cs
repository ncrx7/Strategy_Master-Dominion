using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Characters
{
    public class CharacterLocomotionManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected CharacterManager _characterManager;
        [SerializeField] protected CharacterController _characterController;

        [Header("Properties")]
        [SerializeField] protected float _characterSpeed;
        [SerializeField] protected Vector3 _characterMoveDirection;

        [SerializeField] protected float _rotationSpeed;
    }
}

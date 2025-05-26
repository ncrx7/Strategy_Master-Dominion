using UnityEngine;

namespace Characters.Services.Move
{
    public class CharacterControllerMoveService : IMoveService<CharacterController>
    {
        public void Move(CharacterController controller, Vector3 dir, float speed)
        {
            controller.Move(speed * Time.deltaTime * dir);
        }
    }
}

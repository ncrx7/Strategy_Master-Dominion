using UnityEngine;

namespace Characters.Services.Move
{
    public interface IMoveService<T>
    {
        public void Move(T controller, Vector3 dir, float speed);
    }
}

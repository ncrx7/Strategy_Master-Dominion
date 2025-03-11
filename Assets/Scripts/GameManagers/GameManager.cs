using UnityEngine;

namespace GameManagers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            GameEventHandler.OnVillageSceneStart?.Invoke();
        }

        private void OnDisable()
        {
            GameEventHandler.OnVillageSceneExit?.Invoke();
        }
    }
}

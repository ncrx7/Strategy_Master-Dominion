using UnityEngine;
using UnityUtils.BaseClasses;

namespace Core
{
    public class GameManager : SingletonBehavior<GameManager>
    {
        public Enums.PlatformType deviceType;
        
        private void Start()
        {
            GameEventHandler.OnVillageSceneStart?.Invoke(deviceType);
        
        }

        private void OnDisable()
        {
            GameEventHandler.OnVillageSceneExit?.Invoke(deviceType);
        }
    }
}

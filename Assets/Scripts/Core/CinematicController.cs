using System.Collections.Generic;
using Data;
using Enums;
using UnityEngine;
using UnityEngine.Playables;
using UnityUtils.BaseClasses;

namespace Core
{
    public class CinematicController : BaseCinematicController<CinematicType>
    {

        private void OnEnable()
        {
            GameEventHandler.OnVillageSceneStart += PlayStarterCinematic;
        }

        private void OnDisable()
        {
            GameEventHandler.OnVillageSceneStart -= PlayStarterCinematic;
        }

        private void PlayStarterCinematic(PlatformType platformType)
        {
            var cinematic = GetCinematic(CinematicType.StarterCinematic);
            
            if (cinematic == null && GameDataManager.Instance.GetPlayerDataObjectReference().IsFirstEntry)
            {
                cinematic.PlayCinematic();
            }
        }
    }
}

public enum CinematicType
{
    StarterCinematic
}

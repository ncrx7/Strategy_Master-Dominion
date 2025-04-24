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
            GameEventHandler.OnVillageSceneStart += EntryCinematicBehaviour;
        }

        private void OnDisable()
        {
            GameEventHandler.OnVillageSceneStart -= EntryCinematicBehaviour;
        }

        //ENTRY CINEMATIC HEAD
        private void EntryCinematicBehaviour(PlatformType platformType)
        {
            PlayCinematic(CinematicType.StarterCinematic, GameDataManager.Instance.GetPlayerDataObjectReference().IsFirstEntry, OnEntryCinematicStopped );
        }

        private void OnEntryCinematicStopped(PlayableDirector director) 
        {
            director.stopped -= OnEntryCinematicStopped;
        }
        //ENTRY CINEMATIC END
    }
}

public enum CinematicType
{
    StarterCinematic
}

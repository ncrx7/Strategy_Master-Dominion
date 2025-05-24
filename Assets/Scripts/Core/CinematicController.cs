using System.Collections.Generic;
using Data;
using Enums;
using UnityEngine;
using UnityEngine.Playables;
using UnityUtils.BaseClasses;
using Zenject;

namespace Core
{
    public class CinematicController : BaseCinematicController<CinematicType>
    {
        private GameDataManager _gameDataManager;

        [Inject]
        private void InjectDependencies(GameDataManager gameDataManager)
        {
            _gameDataManager = gameDataManager;
        }

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
            PlayCinematic(CinematicType.StarterCinematic, _gameDataManager.GetPlayerDataObjectReference().IsFirstEntry, OnEntryCinematicStopped);
        }

        private void OnEntryCinematicStopped(PlayableDirector director)
        {
            director.stopped -= OnEntryCinematicStopped;
            GameEventHandler.OnCinematicEnd?.Invoke();
        }
        //ENTRY CINEMATIC END
    }
}

public enum CinematicType
{
    StarterCinematic
}

using System.Collections.Generic;
using Data;
using Enums;
using EventChanells;
using UnityEngine;
using UnityEngine.Playables;
using UnityUtils.BaseClasses;
using Zenject;

namespace Core
{
    public class CinematicController : BaseCinematicController<CinematicType>
    {
        private GameDataManager _gameDataManager;
        private SignalBus _signalBus;

        [Inject]
        private void InjectDependencies(GameDataManager gameDataManager, SignalBus signalBus)
        {
            _gameDataManager = gameDataManager;
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<VillageSceneStartSignal>(EntryCinematicBehaviour);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<VillageSceneStartSignal>(EntryCinematicBehaviour);
        }

        //ENTRY CINEMATIC HEAD
        private void EntryCinematicBehaviour(VillageSceneStartSignal signalResponse)
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

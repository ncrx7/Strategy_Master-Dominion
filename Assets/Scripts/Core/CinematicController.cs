using System;
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

        protected override void PlayCinematic(CinematicType type, bool condition, Action startCallback = null, Action<PlayableDirector> stoppedCallBack = null)
        {
            base.PlayCinematic(type, condition, startCallback, stoppedCallBack);

        }

        //ENTRY CINEMATIC HEAD
        private void EntryCinematicBehaviour(VillageSceneStartSignal signalResponse)
        {
            PlayCinematic(CinematicType.StarterCinematic, _gameDataManager.GetPlayerDataObjectReference().IsFirstEntry,
                () => _signalBus.TryFire(new CinematicStartedSignal()), OnEntryCinematicStopped);
        }

        private void OnEntryCinematicStopped(PlayableDirector director)
        {
            director.stopped -= OnEntryCinematicStopped;

            _signalBus.TryFire(new CinematicEndSignal());
        }
        //ENTRY CINEMATIC END
    }
}

public enum CinematicType
{
    StarterCinematic
}

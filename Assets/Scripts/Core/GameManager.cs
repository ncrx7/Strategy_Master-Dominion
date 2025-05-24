using EventChanells;
using UnityEngine;
using UnityUtils.BaseClasses;
using Zenject;

namespace Core
{
    public class GameManager : SingletonBehavior<GameManager>
    {
        public Enums.PlatformType deviceType;
        private SignalBus _signalBus;

        [Inject]
        private void InjectDependencies(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.TryFire(new VillageSceneStartSignal(deviceType));

        }

        private void OnDisable()
        {
            _signalBus.TryFire(new VillageSceneExitSignal(deviceType));
        }
    }
}

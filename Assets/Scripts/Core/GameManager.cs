using Characters.Player;
using Data.Configs;
using EventChanells;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityUtils.BaseClasses;
using Zenject;

namespace Core
{
    public class GameManager : SingletonBehavior<GameManager>
    {
        public Enums.PlatformType deviceType;
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        private PlayerManager _playerSceneReference;

        private SignalBus _signalBus;
        private DiContainer _sceneContainer;
        private VillageSceneConfigs _sceneConfigs;

        [Inject]
        private void InjectDependencies(SignalBus signalBus, DiContainer sceneContainer, VillageSceneConfigs villageSceneConfigs)
        {
            _signalBus = signalBus;
            _sceneContainer = sceneContainer;
            _sceneConfigs = villageSceneConfigs;
        }

        private void Start()
        {
            _signalBus.TryFire(new VillageSceneStartSignal(deviceType));

            SpawnPlayer();

        }

        private void OnDisable()
        {
            _signalBus.TryFire(new VillageSceneExitSignal(deviceType));
        }

        private void SpawnPlayer()
        {
            Addressables.LoadAssetAsync<GameObject>(_sceneConfigs.PlayerPrefab).Completed += handle =>
            {
                var player = _sceneContainer.InstantiatePrefab(handle.Result);
                _playerSceneReference = player.GetComponent<PlayerManager>();

                SetCamera();
            };
        }

        private void SetCamera()
        {
            if (_cinemachineCamera != null)
            {
                _cinemachineCamera.Follow = _playerSceneReference.transform;
                _cinemachineCamera.LookAt = _playerSceneReference.transform;
            }
        }

        public PlayerManager GetPlayerSceneReference => _playerSceneReference;
    }
}

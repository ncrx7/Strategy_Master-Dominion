using Data.Configs;
using InputHandler;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class VillageSceneInstaller : MonoInstaller
    {
        [Inject] private VillageSceneConfigs _villageSceneConfigs;

        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

using Data.Configs;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class VillageSceneInstaller : MonoInstaller
    {
        [Inject] private VillageSceneConfigs _villageSceneConfigs;

        public override void InstallBindings()
        {

        }
    }
}

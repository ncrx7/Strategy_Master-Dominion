using Data.Configs;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    [CreateAssetMenu(fileName = "VillageSceneSOInstaller", menuName = "Installers/VillageSceneSOInstaller")]
    public class VillageSceneSOInstaller : ScriptableObjectInstaller<VillageSceneSOInstaller>
    {
        [SerializeField] private VillageSceneConfigs _villageSceneConfigs;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<VillageSceneConfigs>().FromInstance(_villageSceneConfigs);
        }
    }
}
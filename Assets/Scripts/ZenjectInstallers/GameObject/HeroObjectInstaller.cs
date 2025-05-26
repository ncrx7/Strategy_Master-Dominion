using Characters;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class HeroObjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterManager<CharacterController>>().To<HeroManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

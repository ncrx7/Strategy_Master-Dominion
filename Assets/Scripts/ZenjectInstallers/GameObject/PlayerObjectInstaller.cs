using Characters;
using Characters.Player;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class PlayerObjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterManager>().To<PlayerManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterLocomotionManager>().To<PlayerLocomotionManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

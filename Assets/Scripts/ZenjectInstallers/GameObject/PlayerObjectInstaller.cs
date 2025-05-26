using Characters;
using Characters.Player;
using Characters.Services.Move;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class PlayerObjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterLocomotionManager<CharacterController>>().To<PlayerLocomotionManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterManager<CharacterController>>().To<PlayerManager>().FromComponentInHierarchy().AsSingle();

            Container.Bind<IMoveService<CharacterController>>().To<CharacterControllerMoveService>().AsSingle();
        }
    }
}

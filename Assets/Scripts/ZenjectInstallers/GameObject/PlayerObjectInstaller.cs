using Characters;
using Characters.Player;
using Characters.Services.Move;
using Name;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class PlayerObjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterManager<CharacterController>>().To<PlayerManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterLocomotionManager<CharacterController>>().To<PlayerLocomotionManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CharacterAnimationManager<CharacterController>>().To<PlayerAnimationManager>().FromComponentInHierarchy().AsSingle();

            Container.Bind<IMoveService<CharacterController>>().To<CharacterControllerMoveService>().AsSingle();
        }
    }
}

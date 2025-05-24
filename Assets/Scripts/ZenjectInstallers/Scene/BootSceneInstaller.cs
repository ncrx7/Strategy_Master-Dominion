using UnityEngine;
using UnityUtils.SceneManagement.Views;
using Zenject;

namespace ZenjectInstallers
{
    public class BootSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().FromComponentInHierarchy().AsSingle();
        }
    }
}

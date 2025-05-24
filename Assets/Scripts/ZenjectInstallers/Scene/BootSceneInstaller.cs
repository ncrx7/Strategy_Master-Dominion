using UnityEngine;
using UnityUtils.SceneManagement.Views;
using Zenject;

namespace ZenjectInstallers
{
    public class BootSceneInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader _sceneLoader;
        public override void InstallBindings()
        {
            //Container.Bind<SceneLoader>().FromComponentInHierarchy().AsSingle();
            ProjectContext.Instance.Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }
    }
}

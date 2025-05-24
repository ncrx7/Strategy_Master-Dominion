using Core;
using EventChanells;
using UnityEngine;
using UnityUtils.SceneManagement.Views;
using Zenject;

namespace ZenjectInstallers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            DeclareSignals();

            HandleBindings();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<SceneLoadedSignal>();
        }

        private void HandleBindings()
        {
            Container.Bind<GameDataManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

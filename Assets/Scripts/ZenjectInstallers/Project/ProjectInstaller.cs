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

        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<SceneLoadedSignal>();
        }
    }
}

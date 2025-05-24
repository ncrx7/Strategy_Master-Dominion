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

            Container.DeclareSignal<VillageSceneStartSignal>();
            Container.DeclareSignal<VillageSceneExitSignal>();

            Container.DeclareSignal<ArenaSceneStartSignal>();
            Container.DeclareSignal<ArenaSceneExitSignal>();

            Container.DeclareSignal<ClickedHomePanelButton>();
            Container.DeclareSignal<ClickedInventoryPanelButton>();
            Container.DeclareSignal<ClickedShopPanelButton>();
            Container.DeclareSignal<ClickedStartGameButton>();

            Container.DeclareSignal<CompletedGameDataLoadingSignal>();
        }

        private void HandleBindings()
        {
            Container.Bind<GameDataManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

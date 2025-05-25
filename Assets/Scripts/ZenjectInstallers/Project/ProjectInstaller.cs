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
            Container.DeclareSignal<SceneLoadedStartedSignal>();
            Container.DeclareSignal<SceneLoadedEndSignal>();

            Container.DeclareSignal<VillageSceneStartSignal>();
            Container.DeclareSignal<VillageSceneExitSignal>();

            Container.DeclareSignal<ArenaSceneStartSignal>();
            Container.DeclareSignal<ArenaSceneExitSignal>();

            Container.DeclareSignal<ClickedHomePanelButton>();
            Container.DeclareSignal<ClickedInventoryPanelButton>();
            Container.DeclareSignal<ClickedShopPanelButton>();
            Container.DeclareSignal<ClickedStartGameButton>();

            Container.DeclareSignal<CompletedGameDataLoadingSignal>();

            Container.DeclareSignal<CinematicStartedSignal>();
            Container.DeclareSignal<CinematicEndSignal>();
        }

        private void HandleBindings()
        {
            Container.Bind<GameDataManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}

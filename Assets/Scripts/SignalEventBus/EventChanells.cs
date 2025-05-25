using Data;
using Enums;
using UnityEngine;

namespace EventChanells
{
    public class SceneLoadedStartedSignal
    {
        public SceneLoadedStartedSignal()
        {

        }
    }

    public class SceneLoadedEndSignal
    {
        public SceneLoadedEndSignal()
        {

        }
    }

    public class VillageSceneStartSignal
    {
        public PlatformType platformType;

        public VillageSceneStartSignal(PlatformType platformType)
        {
            this.platformType = platformType;
        }
    }

    public class VillageSceneExitSignal
    {
        public PlatformType platformType;

        public VillageSceneExitSignal(PlatformType platformType)
        {
            this.platformType = platformType;
        }
    }

    public class ArenaSceneStartSignal
    {
        public PlatformType platformType;

        public ArenaSceneStartSignal(PlatformType platformType)
        {
            this.platformType = platformType;
        }
    }

    public class ArenaSceneExitSignal
    {
        public PlatformType platformType;

        public ArenaSceneExitSignal(PlatformType platformType)
        {
            this.platformType = platformType;
        }
    }

    public struct StartedGameDataLoadingSignal {}

    public class CompletedGameDataLoadingSignal
    {
        public PlayerData playerData;

        public CompletedGameDataLoadingSignal(PlayerData playerData)
        {
            this.playerData = playerData;
        }
    }

    public struct CinematicStartedSignal { }
    public struct CinematicEndSignal { }

    public struct ClickedHomePanelButton { }
    public struct ClickedInventoryPanelButton { }
    public struct ClickedShopPanelButton { }
    public struct ClickedStartGameButton { }
}

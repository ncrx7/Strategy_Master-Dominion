using Enums;
using UnityEngine;

namespace EventChanells
{
    public class SceneLoadedSignal
    {
        public SceneLoadedSignal()
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
}

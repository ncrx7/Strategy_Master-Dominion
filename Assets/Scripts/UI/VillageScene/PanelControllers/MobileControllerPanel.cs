using Data;
using Enums;
using UnityEngine;
using UnityUtils.BaseClasses;

namespace UI.VillageScene.PanelControllers
{
    public class MobileControllerPanel : BasePanel<VillageSceneGamePanelType, PlayerData>
    {
        public override void OnOpenPanel(PlayerData data)
        {
            base.OnOpenPanel(data);
        }

        public override void OnClosePanel(PlayerData data)
        {
            base.OnClosePanel(data);
        }
    }
}

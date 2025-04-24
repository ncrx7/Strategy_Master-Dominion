using Data;
using Enums;
using UI.VillageScene.PanelControllers;
using UnityEngine;
using UnityUtils.BaseClasses;

namespace UI.VillageScene
{
    public class VillageSceneUIManager : BaseUIManager<VillageSceneGamePanelType, PlayerData>
    {


        private void OnEnable()
        {
            GameEventHandler.OnVillageSceneStart += SetInitialPlatformBasedPanels;
        }

        private void OnDisable()
        {
            GameEventHandler.OnVillageSceneStart -= SetInitialPlatformBasedPanels;
        }

        private void SetInitialPlatformBasedPanels(PlatformType platformType)
        {
            switch (platformType)
            {
                case PlatformType.PC:
                    Debug.Log("PC ");
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, GetPanel<MobileControllerPanel>(VillageSceneGamePanelType.MobileControllerPanel).gameObject);
                    break;
                case PlatformType.Mobile:
                Debug.Log("MOBİLE");
                    ExecuteUIAction(UIActionType.SetPanelVisibility, true, GetPanel<MobileControllerPanel>(VillageSceneGamePanelType.MobileControllerPanel).gameObject);
                    break;
                default:
                    Debug.LogWarning("Undefined Platform Type!!");
                    break;
            }
        }


    }
}

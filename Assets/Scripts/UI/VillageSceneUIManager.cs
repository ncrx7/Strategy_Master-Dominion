using Data;
using Enums;
using UnityEngine;
using UnityUtils.BaseClasses;

namespace UI.VillageScene
{
    public class VillageSceneUIManager : BaseUIManager<VillageSceneGamePanelType, PlayerData>
    {
        [SerializeField] private GameObject _touchPanel;

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
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _touchPanel);
                    break;
                case PlatformType.Mobile:
                Debug.Log("MOBİLE");
                    ExecuteUIAction(UIActionType.SetPanelVisibility, true, _touchPanel);
                    break;
                default:
                    Debug.LogWarning("Undefined Platform Type!!");
                    break;
            }
        }


    }
}

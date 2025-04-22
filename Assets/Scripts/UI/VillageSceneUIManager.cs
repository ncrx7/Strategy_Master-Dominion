using Enums;
using UnityEngine;
using UnityUtils.BaseClasses;

namespace VillageSceneUI
{
    public class VillageSceneUIManager : SingletonBehavior<VillageSceneUIManager>
    {
        [SerializeField] private GameObject _touchPanel;

        public void SetPanel(GamePanelType panelType, bool active)
        {
            switch (panelType)
            {
                case GamePanelType.JoyStickPanel:
                    _touchPanel.SetActive(active);
                    break;
                default:
                    Debug.LogWarning("Undefined Panel Type!!");
                    break;
            }
        }
    }
}

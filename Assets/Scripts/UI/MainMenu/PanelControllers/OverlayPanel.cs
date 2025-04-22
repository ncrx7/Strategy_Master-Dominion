using Data;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;

namespace UI.MainMenu.PanelControllers
{
    public class OverlayPanel : BasePanel<MainPanelType, PlayerData>
    {

        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _homePanelButton;
        [SerializeField] private Button _inventoryPanelButton;
        [SerializeField] private Button _shopPanelButton;

        public override void OnOpenPanel(PlayerData playerData)
        {
            base.OnOpenPanel(playerData);

        }

        public override void OnClosePanel(PlayerData playerData)
        {
            base.OnClosePanel(playerData);

        }

        public TextMeshProUGUI GetLevelText => _levelText;
        public TextMeshProUGUI GetgoldText => _goldText;
        public Button GetHomePanelButton => _homePanelButton;
        public Button GetInventoryPanelButton => _inventoryPanelButton;
        public Button GetShopPanelButton => _shopPanelButton;

    }
}

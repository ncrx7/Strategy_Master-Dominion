using Core;
using Cysharp.Threading.Tasks;
using Data;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;
using Zenject;

namespace UI.MainMenu.PanelControllers
{
    public class OverlayPanel : BasePanel<MainPanelType, PlayerData>
    {

        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _homePanelButton;
        [SerializeField] private Button _inventoryPanelButton;
        [SerializeField] private Button _shopPanelButton;
        
        [Inject] private GameDataManager _gameDataManager;

        public async override void OnOpenPanel(PlayerData playerData)
        {
            base.OnOpenPanel(playerData);

            await UniTask.WaitUntil(() => _gameDataManager.IsDataLoadFinished); //EXTRA CHECK, NORMALLY THIS DOES NOT EXECUTE UNLESS GAME DATA LOAD

            _goldText.text = playerData.GoldAmount.ToString();
            _levelText.text = playerData.CurrentLevel.ToString();
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

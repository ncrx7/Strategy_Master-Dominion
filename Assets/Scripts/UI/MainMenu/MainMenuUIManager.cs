using System;
using System.Collections.Generic;
using Data;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;

namespace UI
{
    public class MainMenuUIManager : BaseUIManager<MainPanelType, PlayerData>
    {
        [Header("Overlay Panel References")]
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _homePanelButton;
        [SerializeField] private Button _inventoryPanelButton;
        [SerializeField] private Button _shopPanelButton;

        [SerializeField]private GameObject _currentPanelDisplaying;
        [SerializeField]private GameObject _currentButtonObject;

        protected override void Awake()
        {
            base.Awake();

            InitializeUI();
        }

        private void OnEnable()
        {
            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _mainPanelMap[MainPanelType.LoadingPanel].gameObject);

            GameEventHandler.OnCompleteGameDataLoad += OnCompleteGameDataLoad;

            GameEventHandler.OnClickHomePanelButton += OnClickHomePanelButton;

            GameEventHandler.OnClickInventoryPanelButton += OnClickInventoryPanelButton;

            GameEventHandler.OnClickShopPanelButton += OnClickShopPanelButton;
        }

        private void OnDisable()
        {
            GameEventHandler.OnCompleteGameDataLoad -= OnCompleteGameDataLoad;

            GameEventHandler.OnClickHomePanelButton -= OnClickHomePanelButton;

            GameEventHandler.OnClickInventoryPanelButton -= OnClickInventoryPanelButton;

            GameEventHandler.OnClickShopPanelButton -= OnClickShopPanelButton;
        }

        private void InitializeUI()
        {
            //CAN BE ADDED CUSTOM UI ACTIONS
            _currentButtonObject = _homePanelButton.gameObject;
            _currentButtonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            _currentPanelDisplaying = _mainPanelMap[MainPanelType.HomePanel].gameObject;

            BindButtonActions();
        }

        private void OnCompleteGameDataLoad(PlayerData playerData)
        {
            ExecuteUIAction(UIActionType.SetText, playerData.GoldAmount.ToString(), _goldText);
            ExecuteUIAction(UIActionType.SetText, playerData.CurrentLevel.ToString(), _levelText);

            ExecuteUIAction(UIActionType.SetPanelVisibility, false, _mainPanelMap[MainPanelType.LoadingPanel].gameObject);
        }

        private void OnClickHomePanelButton()
        {
            BaseInteractOnPanelButtonClicking(_homePanelButton.gameObject, _mainPanelMap[MainPanelType.HomePanel]);
        }

        private void OnClickInventoryPanelButton()
        {
            BaseInteractOnPanelButtonClicking(_inventoryPanelButton.gameObject, _mainPanelMap[MainPanelType.InventoryPanel]);
        }

        private void OnClickShopPanelButton()
        {
            BaseInteractOnPanelButtonClicking(_shopPanelButton.gameObject, _mainPanelMap[MainPanelType.ShopPanel]);
        }

        private void BindButtonActions()
        {
            _homePanelButton.onClick.AddListener(() => GameEventHandler.OnClickHomePanelButton?.Invoke());
            _inventoryPanelButton.onClick.AddListener(() => GameEventHandler.OnClickInventoryPanelButton?.Invoke());
            _shopPanelButton.onClick.AddListener(() => GameEventHandler.OnClickShopPanelButton?.Invoke());
        }

        private void BaseInteractOnPanelButtonClicking(GameObject buttonObject, BasePanel<MainPanelType, PlayerData> panelObject)
        {
            if (_currentButtonObject != null)
                _currentButtonObject.transform.localScale = Vector3.one;

            if (_currentPanelDisplaying != null)
                ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

            buttonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            _currentButtonObject = buttonObject.gameObject;

            _currentPanelDisplaying = panelObject.gameObject;

            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _currentPanelDisplaying);

            panelObject.OnOpenPanel(GameDataManager.Instance.GetPlayerDataObjectReference());
        }
    }
}

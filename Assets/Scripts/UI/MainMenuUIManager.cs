using System;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;

namespace UI
{
    public class MainMenuUIManager : BaseUIManager
    {
        [Header("Panels")]
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private GameObject _homePanel;
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private GameObject _shopPanel;

        [Header("Overlay Panel References")]
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _homePanelButton;
        [SerializeField] private Button _inventoryPanelButton;
        [SerializeField] private Button _shopPanelButton;

        private GameObject _currentPanelDisplaying;
        private GameObject _currentButtonObject;

        protected override void Awake()
        {
            base.Awake();

            //CAN BE ADDED CUSTOM UI ACTIONS
            _currentButtonObject = _homePanelButton.gameObject;
            _currentButtonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            _currentPanelDisplaying = _homePanel;

            BindButtonActions();
        }

        private void OnEnable()
        {
            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _loadingPanel);

            GameEventHandler.OnCompleteDataLoad += (PlayerData playerData) =>
            {
                ExecuteUIAction(UIActionType.SetText, playerData.GoldAmount.ToString(), _goldText);
                ExecuteUIAction(UIActionType.SetText, playerData.CurrentLevel.ToString(), _levelText);

                ExecuteUIAction(UIActionType.SetPanelVisibility, false, _loadingPanel);
            };

            GameEventHandler.OnClickHomePanelButton += () =>
            {
                BaseInteractOnPanelButtonClicking(_homePanelButton.gameObject, _homePanel);
            };

            GameEventHandler.OnClickInventoryPanelButton += () =>
            {
                BaseInteractOnPanelButtonClicking(_inventoryPanelButton.gameObject, _inventoryPanel);
            };

            GameEventHandler.OnClickShopPanelButton += () =>
            {
                BaseInteractOnPanelButtonClicking(_shopPanelButton.gameObject, _shopPanel);
            };
        }

        private void OnDisable()
        {
            GameEventHandler.OnCompleteDataLoad -= (PlayerData playerData) =>
            {
                ExecuteUIAction(UIActionType.SetText, playerData.GoldAmount.ToString(), _goldText);
                ExecuteUIAction(UIActionType.SetText, playerData.CurrentLevel.ToString(), _levelText);

                ExecuteUIAction(UIActionType.SetPanelVisibility, false, _loadingPanel);
            };

            GameEventHandler.OnClickHomePanelButton -= () =>
            {
                BaseInteractOnPanelButtonClicking(_homePanelButton.gameObject, _homePanel);
            };

            GameEventHandler.OnClickInventoryPanelButton -= () =>
            {
                BaseInteractOnPanelButtonClicking(_inventoryPanelButton.gameObject, _inventoryPanel);
            };

            GameEventHandler.OnClickShopPanelButton -= () =>
            {
                BaseInteractOnPanelButtonClicking(_shopPanelButton.gameObject, _shopPanel);
            };
        }

        private void BindButtonActions()
        {
            _homePanelButton.onClick.AddListener(() => GameEventHandler.OnClickHomePanelButton?.Invoke());
            _inventoryPanelButton.onClick.AddListener(() => GameEventHandler.OnClickInventoryPanelButton?.Invoke());
            _shopPanelButton.onClick.AddListener(() => GameEventHandler.OnClickShopPanelButton?.Invoke());
        }

        private void BaseInteractOnPanelButtonClicking(GameObject buttonObject, GameObject panelObject)
        {
            if (_currentButtonObject != null)
                _currentButtonObject.transform.localScale = Vector3.one;

            if (_currentPanelDisplaying != null)
                ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

            buttonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            _currentButtonObject = buttonObject.gameObject;

            _currentPanelDisplaying = panelObject;

            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _currentPanelDisplaying);
        }
    }
}

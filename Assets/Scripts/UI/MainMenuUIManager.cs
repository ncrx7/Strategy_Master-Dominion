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
                if(_currentButtonObject != null)
                    _currentButtonObject.transform.localScale = Vector3.one;

                if(_currentPanelDisplaying != null)
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

                _homePanelButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _currentButtonObject = _homePanelButton.gameObject;

                _currentPanelDisplaying = _homePanel;

                ExecuteUIAction(UIActionType.SetPanelVisibility, true, _homePanel);
            };

            GameEventHandler.OnClickInventoryPanelButton += () =>
            {
                if(_currentButtonObject != null)
                    _currentButtonObject.transform.localScale = Vector3.one;
                
                if(_currentPanelDisplaying != null)
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

                _inventoryPanelButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _currentButtonObject = _inventoryPanelButton.gameObject;

                _currentPanelDisplaying = _inventoryPanel;

                ExecuteUIAction(UIActionType.SetPanelVisibility, true, _inventoryPanel);
            };

            GameEventHandler.OnClickShopPanelButton += () =>
            {
                if(_currentButtonObject != null)
                    _currentButtonObject.transform.localScale = Vector3.one;
                
                if(_currentPanelDisplaying != null)
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

                _shopPanelButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _currentButtonObject = _shopPanelButton.gameObject;

                _currentPanelDisplaying = _shopPanel;

                ExecuteUIAction(UIActionType.SetPanelVisibility, true, _shopPanel);
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

                        GameEventHandler.OnClickHomePanelButton += () =>
            {
                if(_currentButtonObject != null)
                    _currentButtonObject.transform.localScale = Vector3.one;

                if(_currentPanelDisplaying != null)
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

                _homePanelButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _currentButtonObject = _homePanelButton.gameObject;

                _currentPanelDisplaying = _homePanel;

                ExecuteUIAction(UIActionType.SetPanelVisibility, true, _homePanel);
            };

            GameEventHandler.OnClickInventoryPanelButton += () =>
            {
                if(_currentButtonObject != null)
                    _currentButtonObject.transform.localScale = Vector3.one;
                
                if(_currentPanelDisplaying != null)
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

                _inventoryPanelButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _currentButtonObject = _inventoryPanelButton.gameObject;

                _currentPanelDisplaying = _inventoryPanel;

                ExecuteUIAction(UIActionType.SetPanelVisibility, true, _inventoryPanel);
            };

            GameEventHandler.OnClickShopPanelButton += () =>
            {
                if(_currentButtonObject != null)
                    _currentButtonObject.transform.localScale = Vector3.one;
                
                if(_currentPanelDisplaying != null)
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);

                _shopPanelButton.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _currentButtonObject = _shopPanelButton.gameObject;

                _currentPanelDisplaying = _shopPanel;

                ExecuteUIAction(UIActionType.SetPanelVisibility, true, _shopPanel);
            };
        }

        private void BindButtonActions()
        {
            _homePanelButton.onClick.AddListener(() => GameEventHandler.OnClickHomePanelButton?.Invoke());
            _inventoryPanelButton.onClick.AddListener(() => GameEventHandler.OnClickInventoryPanelButton?.Invoke());
            _shopPanelButton.onClick.AddListener(() => GameEventHandler.OnClickShopPanelButton?.Invoke());
        }
    }
}

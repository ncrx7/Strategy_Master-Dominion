using System;
using System.Collections.Generic;
using Data;
using Enums;
using TMPro;
using UI.MainMenu.PanelControllers;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;

namespace UI
{
    public class MainMenuUIManager : BaseUIManager<MainPanelType, PlayerData>
    {
        [Header("Overlay Panel References")]

        [SerializeField] private GameObject _currentPanelDisplaying;
        [SerializeField] private GameObject _currentButtonObject;

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
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out var overlayPanel))
            {
                _currentButtonObject = overlayPanel.GetHomePanelButton.gameObject;
                //_currentButtonObject = GetPanel<OverlayPanel>(MainPanelType.OverlayPanel).GetHomePanelButton.gameObject;
            }

            _currentButtonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            _currentPanelDisplaying = _mainPanelMap[MainPanelType.HomePanel].gameObject;

            BindButtonActions();
        }

        private void OnCompleteGameDataLoad(PlayerData playerData)
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                ExecuteUIAction(UIActionType.SetText, playerData.GoldAmount.ToString(), overlayPanel.GetgoldText);
                ExecuteUIAction(UIActionType.SetText, playerData.CurrentLevel.ToString(), overlayPanel.GetLevelText);
            }

            ExecuteUIAction(UIActionType.SetPanelVisibility, false, _mainPanelMap[MainPanelType.LoadingPanel].gameObject);
        }

        private void OnClickHomePanelButton()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                BaseInteractOnPanelButtonClicking(overlayPanel.GetHomePanelButton.gameObject, _mainPanelMap[MainPanelType.HomePanel]);
            }
        }

        private void OnClickInventoryPanelButton()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                BaseInteractOnPanelButtonClicking(overlayPanel.GetInventoryPanelButton.gameObject, _mainPanelMap[MainPanelType.InventoryPanel]);
            }
        }

        private void OnClickShopPanelButton()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                BaseInteractOnPanelButtonClicking(overlayPanel.GetShopPanelButton.gameObject, _mainPanelMap[MainPanelType.ShopPanel]);
            }
        }

        private void BindButtonActions()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                overlayPanel.GetHomePanelButton.onClick.AddListener(() => GameEventHandler.OnClickHomePanelButton?.Invoke());
                overlayPanel.GetInventoryPanelButton.onClick.AddListener(() => GameEventHandler.OnClickInventoryPanelButton?.Invoke());
                overlayPanel.GetShopPanelButton.onClick.AddListener(() => GameEventHandler.OnClickShopPanelButton?.Invoke());
            }
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

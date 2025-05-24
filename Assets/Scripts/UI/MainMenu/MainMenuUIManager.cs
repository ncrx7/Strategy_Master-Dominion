using System;
using System.Collections.Generic;
using Core;
using Data;
using Enums;
using TMPro;
using UI.MainMenu.PanelControllers;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;
using Zenject;

namespace UI.MainMenu
{
    public class MainMenuUIManager : BaseUIManager<MainPanelType, PlayerData>
    {
        [Header("Overlay Panel References")]

        [SerializeField] private GameObject _currentPanelDisplaying;
        [SerializeField] private GameObject _currentButtonObject;
        private GameDataManager _gameDataManager;

        [Inject]
        private void InjectDependencies(GameDataManager gameDataManager)
        {
            _gameDataManager = gameDataManager;
        }

        protected override void Awake()
        {
            base.Awake();

            InitializeUI();
        }

        private void OnEnable()
        {
            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _mainPanelMap[MainPanelType.LoadingPanel].gameObject);

            RegisterUIActions();
        }

        private void OnDisable()
        {
            UnRegisterUIActions();
        }

        private void RegisterUIActions()
        {
            GameEventHandler.OnCompleteGameDataLoad += CompleteGameDataLoadUIBehaviour;

            GameEventHandler.OnClickHomePanelButton += HomePanelButtonBehaviour;

            GameEventHandler.OnClickInventoryPanelButton += InventoryPanelButtonBehaviour;

            GameEventHandler.OnClickShopPanelButton += ShopPanelButtonBehaviour;

            GameEventHandler.OnSceneLoadStart += OnSceneLoadStart;

            GameEventHandler.OnSceneLoadFinished += OnSceneLoadFinished;
        }

        private void UnRegisterUIActions()
        {
            GameEventHandler.OnCompleteGameDataLoad -= CompleteGameDataLoadUIBehaviour;

            GameEventHandler.OnClickHomePanelButton -= HomePanelButtonBehaviour;

            GameEventHandler.OnClickInventoryPanelButton -= InventoryPanelButtonBehaviour;

            GameEventHandler.OnClickShopPanelButton -= ShopPanelButtonBehaviour;

            GameEventHandler.OnSceneLoadStart -= OnSceneLoadStart;

            GameEventHandler.OnSceneLoadFinished -= OnSceneLoadFinished;
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

        private void CompleteGameDataLoadUIBehaviour(PlayerData playerData)
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                ExecuteUIAction(UIActionType.SetText, playerData.GoldAmount.ToString(), overlayPanel.GetgoldText);
                ExecuteUIAction(UIActionType.SetText, playerData.CurrentLevel.ToString(), overlayPanel.GetLevelText);
            }

            ExecuteUIAction(UIActionType.SetPanelVisibility, false, _mainPanelMap[MainPanelType.LoadingPanel].gameObject);
        }

        private void HomePanelButtonBehaviour()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                BasePanelButtonBehaviour(overlayPanel.GetHomePanelButton.gameObject, _mainPanelMap[MainPanelType.HomePanel]);
            }
        }

        private void InventoryPanelButtonBehaviour()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                BasePanelButtonBehaviour(overlayPanel.GetInventoryPanelButton.gameObject, _mainPanelMap[MainPanelType.InventoryPanel]);
            }
        }

        private void ShopPanelButtonBehaviour()
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                BasePanelButtonBehaviour(overlayPanel.GetShopPanelButton.gameObject, _mainPanelMap[MainPanelType.ShopPanel]);
            }
        }

        private void OnSceneLoadStart()
        {
            if (TryGetPanel<LoadingPanel>(MainPanelType.LoadingPanel, out LoadingPanel loadingPanel))
            {
                ExecuteUIAction(UIActionType.SetPanelVisibility, true, loadingPanel.gameObject);
                loadingPanel.OnOpenPanel(_gameDataManager.GetPlayerDataObjectReference());
            }
        }

        private void OnSceneLoadFinished()
        {
            if (TryGetPanel<LoadingPanel>(MainPanelType.LoadingPanel, out LoadingPanel loadingPanel))
            {
                ExecuteUIAction(UIActionType.SetPanelVisibility, false, loadingPanel.gameObject);
                loadingPanel.OnClosePanel(_gameDataManager.GetPlayerDataObjectReference());
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

            if (TryGetPanel<HomePanel>(MainPanelType.HomePanel, out HomePanel homePanel))
            {
                homePanel.GetPlayButton.onClick.AddListener(() => GameEventHandler.OnClickPlayButton?.Invoke());
            }
        }

        private void BasePanelButtonBehaviour(GameObject buttonObject, BasePanel<MainPanelType, PlayerData> panelObject)
        {
            if (_currentButtonObject != null)
                _currentButtonObject.transform.localScale = Vector3.one;

            if (_currentPanelDisplaying != null)
            {
                ExecuteUIAction(UIActionType.SetPanelVisibility, false, _currentPanelDisplaying);
                panelObject.OnClosePanel(_gameDataManager.GetPlayerDataObjectReference());
            }

            buttonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            _currentButtonObject = buttonObject.gameObject;

            _currentPanelDisplaying = panelObject.gameObject;

            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _currentPanelDisplaying);

            panelObject.OnOpenPanel(_gameDataManager.GetPlayerDataObjectReference());
        }
    }
}

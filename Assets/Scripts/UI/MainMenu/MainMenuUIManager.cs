using System;
using System.Collections.Generic;
using Core;
using Data;
using Enums;
using EventChanells;
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
        private SignalBus _signalBus;

        [Inject]
        private void InjectDependencies(GameDataManager gameDataManager, SignalBus signalBus)
        {
            _gameDataManager = gameDataManager;
            _signalBus = signalBus;
        }

        protected override void Awake()
        {
            base.Awake();

            InitializeUI();
        }

        private void OnEnable()
        {
            RegisterUIActions();
        }

        private void OnDisable()
        {
            UnRegisterUIActions();
        }

        private void RegisterUIActions()
        {
            _signalBus.Subscribe<CompletedGameDataLoadingSignal>(CompleteGameDataLoadUIBehaviour);
            _signalBus.Subscribe<StartedGameDataLoadingSignal>(StartGameDataLoadUIBehaviour);

            _signalBus.Subscribe<ClickedHomePanelButton>(HomePanelButtonBehaviour);

            _signalBus.Subscribe<ClickedInventoryPanelButton>(InventoryPanelButtonBehaviour);

            _signalBus.Subscribe<ClickedShopPanelButton>(ShopPanelButtonBehaviour);

            _signalBus.Subscribe<SceneLoadedStartedSignal>(OnSceneLoadStart);
            _signalBus.Subscribe<SceneLoadedEndSignal>(OnSceneLoadFinished);
        }

        private void UnRegisterUIActions()
        {
            _signalBus.Unsubscribe<CompletedGameDataLoadingSignal>(CompleteGameDataLoadUIBehaviour);
            _signalBus.Unsubscribe<StartedGameDataLoadingSignal>(StartGameDataLoadUIBehaviour);

            _signalBus.Unsubscribe<ClickedHomePanelButton>(HomePanelButtonBehaviour);

            _signalBus.Unsubscribe<ClickedInventoryPanelButton>(InventoryPanelButtonBehaviour);

            _signalBus.Unsubscribe<ClickedShopPanelButton>(ShopPanelButtonBehaviour);

            _signalBus.Unsubscribe<SceneLoadedStartedSignal>(OnSceneLoadStart);
            _signalBus.Unsubscribe<SceneLoadedEndSignal>(OnSceneLoadFinished);
        }

        private void InitializeUI()
        {
            //CAN BE ADDED CUSTOM UI ACTIONS
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out var overlayPanel))
            {
                _currentButtonObject = overlayPanel.GetHomePanelButton.gameObject;
                overlayPanel.OnOpenPanel(_gameDataManager.GetPlayerDataObjectReference());
                //_currentButtonObject = GetPanel<OverlayPanel>(MainPanelType.OverlayPanel).GetHomePanelButton.gameObject;
            }

            _currentButtonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            _currentPanelDisplaying = _mainPanelMap[MainPanelType.HomePanel].gameObject;

            BindButtonActions();
        }

        private void StartGameDataLoadUIBehaviour()
        {
            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _mainPanelMap[MainPanelType.LoadingPanel].gameObject);
        }

        private void CompleteGameDataLoadUIBehaviour(CompletedGameDataLoadingSignal signalResponse)
        {
            if (TryGetPanel<OverlayPanel>(MainPanelType.OverlayPanel, out OverlayPanel overlayPanel))
            {
                ExecuteUIAction(UIActionType.SetText, signalResponse.playerData.GoldAmount.ToString(), overlayPanel.GetgoldText);
                ExecuteUIAction(UIActionType.SetText, signalResponse.playerData.CurrentLevel.ToString(), overlayPanel.GetLevelText);
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
                overlayPanel.GetHomePanelButton.onClick.AddListener(() => _signalBus.TryFire(new ClickedHomePanelButton()));
                overlayPanel.GetInventoryPanelButton.onClick.AddListener(() => _signalBus.TryFire(new ClickedInventoryPanelButton()));
                overlayPanel.GetShopPanelButton.onClick.AddListener(() => _signalBus.TryFire(new ClickedShopPanelButton()));
            }

            if (TryGetPanel<HomePanel>(MainPanelType.HomePanel, out HomePanel homePanel))
            {
                homePanel.GetPlayButton.onClick.AddListener(() => _signalBus.TryFire(new ClickedStartGameButton()));
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

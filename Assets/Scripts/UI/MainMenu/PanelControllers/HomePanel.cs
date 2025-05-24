using Data;
using Enums;
using EventChanells;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;
using UnityUtils.SceneManagement.Views;
using Zenject;

namespace UI.MainMenu.PanelControllers
{
    public class HomePanel : BasePanel<MainPanelType, PlayerData>
    {
        [SerializeField] private Button _playButton;
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private SignalBus _signalBus;

        private void Awake()
        {
            //GameEventHandler.OnClickPlayButton += PlayButtonBehaviour;
            _signalBus.Subscribe<ClickedStartGameButton>(PlayButtonBehaviour);
        }

        void OnDestroy()
        {
            //GameEventHandler.OnClickPlayButton -= PlayButtonBehaviour;
            _signalBus.Unsubscribe<ClickedStartGameButton>(PlayButtonBehaviour);
        }

        public override void OnOpenPanel(PlayerData playerData)
        {
            base.OnOpenPanel(playerData);

        }

        public override void OnClosePanel(PlayerData playerData)
        {
            base.OnClosePanel(playerData);

        }

        private async void PlayButtonBehaviour()
        {
            await _sceneLoader.LoadSceneGroup(1, true);
        }

        public Button GetPlayButton => _playButton;
    }
}

using Data;
using Enums;
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

        private void Awake()
        {
            GameEventHandler.OnClickPlayButton += PlayButtonBehaviour;
        }

        void OnDestroy()
        {
            GameEventHandler.OnClickPlayButton -= PlayButtonBehaviour;
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

using Data;
using Enums;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.BaseClasses;
using UnityUtils.StaticHelpers;

namespace UI.MainMenu.PanelControllers
{
    public class HomePanel : BasePanel<MainPanelType, PlayerData>
    {
        [SerializeField] private Button _playButton;

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
           await SceneLoader.LoadSceneAsync(1);
        }

        public Button GetPlayButton => _playButton;
    }
}

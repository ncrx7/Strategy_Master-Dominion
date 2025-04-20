using System;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;
using UnityUtils.BaseClasses;

namespace UI
{
    public class MainMenuUIManager : BaseUIManager
    {
        [Header("Panels")]
        [SerializeField] private GameObject _loadingPanel;

        [Header("Overlay Panel References")]
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _goldText;

        protected override void Awake()
        {
            base.Awake();

            //CAN BE ADDED CUSTOM UI ACTIONS
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
        }

        private void OnDisable()
        {
            GameEventHandler.OnCompleteDataLoad -= (PlayerData playerData) =>
            {
                ExecuteUIAction(UIActionType.SetText, playerData.GoldAmount.ToString(), _goldText);
                ExecuteUIAction(UIActionType.SetText, playerData.CurrentLevel.ToString(), _levelText);
                
                ExecuteUIAction(UIActionType.SetPanelVisibility, false, _loadingPanel);
            };
        }


    }
}

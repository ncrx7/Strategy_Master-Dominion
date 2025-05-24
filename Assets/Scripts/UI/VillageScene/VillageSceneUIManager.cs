using System;
using Data;
using Enums;
using EventChanells;
using UI.VillageScene.PanelControllers;
using UnityEngine;
using UnityUtils.BaseClasses;
using Zenject;

namespace UI.VillageScene
{
    public class VillageSceneUIManager : BaseUIManager<VillageSceneGamePanelType, PlayerData>
    {
        [SerializeField] private GameObject _hud;
        private SignalBus _signalBus;

        [Inject]
        private void InjectDependencies(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<VillageSceneStartSignal>(SetInitialPlatformBasedPanels);

            GameEventHandler.OnCinematicStart += UICinematicStartBehaviour;
            GameEventHandler.OnCinematicEnd += UICinematicEndBehaviour;
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<VillageSceneStartSignal>(SetInitialPlatformBasedPanels);

            GameEventHandler.OnCinematicStart -= UICinematicStartBehaviour;
            GameEventHandler.OnCinematicEnd -= UICinematicEndBehaviour;
        }

        //TODO: BIND PLATFORM UI SERVICE INTERFACE HERE INSTEAD SWITCH CASE
        private void SetInitialPlatformBasedPanels(VillageSceneStartSignal signalResponse)
        {
            switch (signalResponse.platformType)
            {
                case PlatformType.PC:
                    Debug.Log("PC ");
                    ExecuteUIAction(UIActionType.SetPanelVisibility, false, GetPanel<MobileControllerPanel>(VillageSceneGamePanelType.MobileControllerPanel).gameObject);
                    break;
                case PlatformType.Mobile:
                    Debug.Log("MOBİLE");
                    ExecuteUIAction(UIActionType.SetPanelVisibility, true, GetPanel<MobileControllerPanel>(VillageSceneGamePanelType.MobileControllerPanel).gameObject);
                    break;
                default:
                    Debug.LogWarning("Undefined Platform Type!!");
                    break;
            }
        }

        private void UICinematicStartBehaviour()
        {
            ExecuteUIAction(UIActionType.SetPanelVisibility, false, _hud);
        }

        private void UICinematicEndBehaviour()
        {
            ExecuteUIAction(UIActionType.SetPanelVisibility, true, _hud);
        }


    }
}

using System;
using Data;
using Enums;
using UnityEngine;

public class GameEventHandler 
{
    #region Scene Load Events
    public static Action OnSceneLoadStart;
    public static Action OnSceneLoadFinished;
    #endregion

/*     #region Village Scene
    public static Action<PlatformType> OnVillageSceneStart;
    public static Action<PlatformType> OnVillageSceneExit;
    #endregion */
    

    #region Arena Scene
    public static Action OnArenaSceneStart;
    public static Action OnArenaSceneExit;
    #endregion

    #region Main Menu
    public static Action OnClickHomePanelButton;
    public static Action OnClickInventoryPanelButton;
    public static Action OnClickShopPanelButton;
    public static Action OnClickPlayButton;
    #endregion


    #region GamePlay
    public static Action<PlayerData> OnCompleteGameDataLoad;
    public static Action OnCinematicStart;
    public static Action OnCinematicEnd;
    #endregion
}

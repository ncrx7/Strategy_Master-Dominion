using System;
using UnityEngine;

public class GameEventHandler 
{
    #region Village Scene
    public static Action OnVillageSceneStart;
    public static Action OnVillageSceneExit;
    #endregion
    

    #region Arena Scene
    public static Action OnArenaSceneStart;
    public static Action OnArenaSceneExit;
    #endregion


    #region Main Menu
    public static Action OnCompleteDataLoad;
    #endregion
}

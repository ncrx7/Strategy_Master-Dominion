using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public int CurrentLevel;
        public List<DynamicHeroData> Heroes;
        public int GoldAmount;
        public int IncreasePoint;
        public bool IsFirstEntry;

        public PlayerData(int currentLevel, List<DynamicHeroData> heroes, int goldAmount, int increasePoint, bool isFirstEntry)
        {
            CurrentLevel = currentLevel;
            Heroes = heroes;
            GoldAmount = goldAmount;
            IncreasePoint = increasePoint;
            IsFirstEntry = isFirstEntry;
        }
    }
}

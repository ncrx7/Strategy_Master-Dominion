using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class PlayerData
    {
        public int CurrentLevel;
        public List<int> HeroesIds;
        public int GoldAmount;
        public int IncreasePoint;

        public PlayerData(int currentLevel, List<int> heroesIds, int goldAmount, int increasePoint)
        {
            CurrentLevel = currentLevel;
            HeroesIds = heroesIds;
            GoldAmount = goldAmount;
            IncreasePoint = increasePoint;
        }
    }
}

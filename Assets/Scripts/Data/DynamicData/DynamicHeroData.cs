using System;
using Data.Scriptable.Heroes;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class DynamicHeroData
    {
        public int HeroId;
        public int HpStat;
        public int StrStat;
        public int ApStat;
        public int DexStat;
        public FixedHeroData FixedHeroData;

        public DynamicHeroData(int heroId, int hpStat, int strStat, int apStat, int dexStat)
        {
            HeroId = heroId;
            HpStat = hpStat;
            StrStat = strStat;
            ApStat = apStat;
            DexStat = dexStat;
        } 
    }
}

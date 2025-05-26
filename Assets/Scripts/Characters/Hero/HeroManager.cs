using Characters;
using Data;
using Data.Scriptable.Heroes;
using UnityEngine;

namespace Characters
{
    public class HeroManager : CharacterManager<CharacterController>
    {
        public FixedHeroData FixedHeroData;
        public DynamicHeroData DynamicHeroData;
    }
}

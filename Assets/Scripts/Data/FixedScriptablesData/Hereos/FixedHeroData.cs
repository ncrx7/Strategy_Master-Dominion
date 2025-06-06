using Characters;
using UnityEngine;

namespace Data.Scriptable.Heroes
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Scriptable Objects/Hero")]
    public class FixedHeroData : ScriptableObject
    {
        public int HeroId;
        public string HeroName;
        public Sprite UISprite;
        public HeroManager HeroPrefab;
        //hero ability
    }
}

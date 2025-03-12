using UnityEngine;

namespace Data.Scriptable.Heroes
{
    [CreateAssetMenu(fileName = "Hero", menuName = "Scriptable Objects/Hero")]
    public class Hero : ScriptableObject
    {
        public int HeroId;
        public string HeroName;
        public Sprite UISprite;
        //hero ability
    }
}

using UnityEngine;
using UnityEngine.Serialization;


namespace Script.Card
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
    public class Card : ScriptableObject
    {
        public new string Name;
        public int Hp;
        public int Attack;
        public int Manacost;
        
        [TextArea]  
        public string Description;
        public  Types CardType;
        public Sprite CardImage;
        
        [System.Serializable]
        public enum Types
        {
            Tool, Man, Powers, Relic, Heroic
        };
    }
}

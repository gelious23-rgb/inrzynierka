using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public new string name;
  [TextArea]  public string description;

    public  Types CardType; 

    public Sprite cardImage;

    public int hp;
    public int attack;
    public int manacost;
[System.Serializable]
    public enum Types
    {
       Tool, Man, Powers, Relic, Heroic
    };
}

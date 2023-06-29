using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Card
{
    public class CardCompendiumSC : MonoBehaviour
    {
        public Button onclick; 
        public TextMeshProUGUI name_;
        public TextMeshProUGUI desc, Type, hp, atk, cost;
        [SerializeField] public Image artwork; 
    }
}

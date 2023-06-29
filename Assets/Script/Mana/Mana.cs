using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using EasyButtons;
namespace Script.Mana
{
    public class Mana: MonoBehaviour, IMana
    {
        [SerializeField]
        private int _manaValue = 1;
        [SerializeField]
        private int _manaMax;
        private TextMeshProUGUI _mana;

        private void Awake()
        {
            _mana = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        private void Start()
        {
            _mana.text = _manaValue.ToString();
        }
        
        [Button]
        public void Decrease(int decreaseValue)
        {
            _manaValue -= decreaseValue;
            _mana.text = _manaValue.ToString();
            if (_manaValue < 0)
            {
                _manaValue = 0;
                _mana.text = _manaValue.ToString();
            }
            
        }

        [Button]
        public void Increase(int increaseValue)
        {
            _manaValue += increaseValue;
            _mana.text = _manaValue.ToString();

            if (_manaValue > _manaMax)
            {
                ResetMana();
            }
        }

        [Button]
        public void IncreseManaMax(int increaseValue)
        {
            _manaMax += increaseValue;
            _mana.text = _manaMax.ToString();

            if (_manaMax > 10)
            {
                _manaMax = 10;
                _mana.text = _manaMax.ToString();


            }
        }
        public void ResetMana()
        {
            _manaValue = _manaMax;
            _mana.text = _manaValue.ToString();
        }


    }
}
using TMPro;
using UnityEngine;

namespace Script.Mana
{
    public class Mana: MonoBehaviour, IMana
    {

        private int _manaValue = 1;
        private int _manaMax = 1;
        private TextMeshProUGUI _mana;

        public int ManaValue
        {
            get { return _manaValue; } // Getter method
            set { _manaValue = value; } // Setter method
        }

        public int ManaMax
        {
            get { return _manaMax; }
        }

        private void Awake()
        {
            _mana = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        private void Start()
        {
            _mana.text = _manaValue.ToString();
        }
        

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


        public void Increase(int increaseValue)
        {
            _manaValue += increaseValue;
            _mana.text = _manaValue.ToString();

            if (_manaValue >= _manaMax)
            {
                ResetMana();
            }
        }


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
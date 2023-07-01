using TMPro;
using UnityEngine;

namespace Script.Mana
{
    public class Mana: MonoBehaviour, IMana
    {

        private int _manaCurrent = 1;
        private int _manaMax = 1;
        private TextMeshProUGUI _mana;

        public int ManaCurrent
        {
            get => _manaCurrent;
            set => _manaCurrent = value; 
        }

        private void Awake()
        {
            _mana = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            _mana.text = _manaCurrent.ToString();
        }

        public int ManaMax => _manaMax;

        public void Decrease(int decreaseValue)
        {
            _manaCurrent -= decreaseValue;
            _mana.text = _manaCurrent.ToString();
            if (_manaCurrent < 0)
            {
                _manaCurrent = 0;
                _mana.text = _manaCurrent.ToString();
            }
            
        }

        public void Increase(int increaseValue)
        {
            _manaCurrent += increaseValue;
            _mana.text = _manaCurrent.ToString();

            if (_manaCurrent >= _manaMax)
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

        private void ResetMana()
        {
            _manaCurrent = _manaMax;
            _mana.text = _manaCurrent.ToString();
        }



    }
}

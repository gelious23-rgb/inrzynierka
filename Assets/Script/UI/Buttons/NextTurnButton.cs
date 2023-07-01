using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EasyButtons;
using Script.Characters;
using Script.Game;
using TMPro;
using UnityEngine.Serialization;


namespace Script.UI.Buttons
{
    public class NextTurnButton : MonoBehaviour
    {
        private Button _nextTurnButton;
        public TextMeshProUGUI TurnTimerText;
        [SerializeField]
        private BattleBehaviour _battleBehaviour;
        

        private void Awake()
        {
            _nextTurnButton = GetComponent<Button>();
        }

        private void Start()
        {
            _nextTurnButton.onClick.AddListener(NextTurn);
            _nextTurnButton.enabled = true;
        }

        private void OnEnable()
        {
            _nextTurnButton.enabled = true;
        }
        
        private void OnDisable()
        {
            _nextTurnButton.enabled = false;
        }
        
        public void UpdateTurnTimer(float time) => TurnTimerText.text = "Time: " + Mathf.RoundToInt(time).ToString();

        private void NextTurn() => _battleBehaviour.SkipPlayerTurn();
    }
}
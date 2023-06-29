using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EasyButtons;
using Script.Characters;


namespace Script.UI.Buttons
{
    public class NextTurnButton : MonoBehaviour
    {
        private Button _diceButton;
        
        [SerializeField]
        private Player _bot;

        private void Awake()
        {
            _diceButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _diceButton.onClick.AddListener(Press);
        }
        
        /*
        public void SetBot(Player bot) => 
            _bot = bot;*/

        [Button]
        private void Press()
        {
            StartCoroutine(PressCoroutine());
        }


        private IEnumerator PressCoroutine()
        {
            _diceButton.enabled = false;
            yield return _bot.TurnBot();
        }

        private void OnDisable()
        {
            _diceButton.onClick.RemoveListener(Press);
            _diceButton.enabled = true;

        }
    }
}
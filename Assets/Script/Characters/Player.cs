using System.Collections;
using Script.Game;
using Script.UI.Buttons;
using UnityEngine;

namespace Script.Characters
{
    public class Player : MonoBehaviour 
    {

        [field: SerializeField]
        public bool IsPlayer { get; private set; }
        [field: SerializeField]
        public Health.Health HealthObject { get; set; }
        public Mana.Mana ManaObject { get; set; }

        private NextTurnButton _nextTurnButton;
        private BoardManager _boardManager;


        public Player(NextTurnButton nextTurnButton)
        {
            _nextTurnButton = nextTurnButton;
        }
        private void Awake()
        {
            HealthObject = GetComponentInChildren<Health.Health>();
        }
    


        public IEnumerator TurnBot()
        {
        
            _nextTurnButton.gameObject.SetActive(false);
            // yield return _board.AddCardToHand(2);
            yield return new WaitForSeconds(5.0f);
            Debug.Log("AI Bot Turn");


        }

        public IEnumerator TurnPlayer(int _cardAmount)
        {
            for (int i = 0; i < _cardAmount; i++)
            {
                _nextTurnButton.gameObject.SetActive(true);
                yield break;
            }
        
            _nextTurnButton.gameObject.SetActive(false);
        }

        private IEnumerator WaitForPlayerAction()
        {
            yield return null;
        }
    

        public void AddMana()
        {
            ManaObject.Increase(1);
            ManaObject.IncreseManaMax(1);
        }
    
        



    }
}

using System.Collections;
using Script.Game;
using Script.UI.Buttons;
using UnityEngine;

namespace Script.Characters
{
    public class Player : MonoBehaviour
    {
        
        [field: SerializeField]
        public Health.Health HealthObject { get; set; }
        public Mana.Mana ManaObject { get; set; }

        private NextTurnButton _nextTurnButton;
        private BoardManager _boardManager;
        
        public string playerName;
        private bool shouldSkipTurn;


        public Player(NextTurnButton nextTurnButton)
        {
            _nextTurnButton = nextTurnButton;
        }
        private void Awake()
        {
            HealthObject = GetComponentInChildren<Health.Health>();
            ManaObject = GetComponentInChildren<Mana.Mana>();
        }
    
        public  void StartTurn()
        {
            Debug.Log("Start of turn for " + playerName);
            AddMana();
            shouldSkipTurn = false;
            
            // Perform player-specific actions at the start of the turn
        }
        
        public void EndTurn()
        {
            Debug.Log("End of turn for " + playerName);
            // Perform player-specific actions at the end of the turn
        }
        
        public bool ShouldSkipTurn()
        {
            return shouldSkipTurn;
        }
    
        public void AddMana()
        {
            ManaObject.IncreseManaMax(1);
            ManaObject.Increase(1);
        }
    
        



    }
}

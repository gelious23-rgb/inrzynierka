using Script.Game;
using Script.UI.Buttons;
using UnityEngine;

namespace Script.Characters
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Health.Health HealthObject { get; set; }
        public Mana.Mana ManaObject { get; set; }

        private NextTurnButton _nextTurnButton;
        private BoardManager _boardManager;

        public string PlayerName;
        private bool _shouldSkipTurn;


        public Player(NextTurnButton nextTurnButton)
        {
            _nextTurnButton = nextTurnButton;
        }

        private void Awake()
        {
            HealthObject = GetComponentInChildren<Health.Health>();
            ManaObject = GetComponentInChildren<Mana.Mana>();
        }

        public void StartTurn()
        {
            Debug.Log("Start of turn for " + PlayerName);
            ManaObject.ManaCurrent = ManaObject.ManaMax;
            AddMana();
            _shouldSkipTurn = false;
        }

        public void EndTurn()
        {
            Debug.Log("End of turn for " + PlayerName);
        }

        public bool ShouldSkipTurn()
        {
            return _shouldSkipTurn;
        }

        private void AddMana()
        {
            ManaObject.IncreseManaMax(1);
            ManaObject.Increase(1);
        }
    }
}
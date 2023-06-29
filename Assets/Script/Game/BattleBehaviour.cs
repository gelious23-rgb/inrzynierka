using System.Collections;
using System.Collections.Generic;
using Script.Characters;
using Script.UI.Buttons;
using Script.UI.Panel;
using UnityEngine;

namespace Script.Game
{
    public class BattleBehaviour : MonoBehaviour
    {
        public Player humanPlayer;
        public BotPlayer botPlayer;
        private Player _activePlayer;
        
        [SerializeField]
        private BoardManager _boardManager;
        [SerializeField]
        private NextTurnButton _nextTurnButton;
        private WinPanel _winPanel;
        private LosePanel _losePanel;
        
        private bool _playerTurnSkipped;
        public float turnTimeLimit = 30f;
        private float _turnTimer;
        
        private void Start()
        {
            _activePlayer = humanPlayer;
            StartTurn();
        }
        
        private void StartTurn()
         {
             _activePlayer.StartTurn();
             _playerTurnSkipped = false;
             _turnTimer = turnTimeLimit;

             if (_activePlayer == humanPlayer)
             {
                 _nextTurnButton.gameObject.SetActive(true);
                 StartCoroutine(TurnPlayer());
             }
             else
             {
                 StartCoroutine(TurnBot());
             }
         }
        
        public void SkipPlayerTurn()
        {
            if (_activePlayer == humanPlayer)
            {
                _playerTurnSkipped = true;
                _nextTurnButton.gameObject.SetActive(false);
                EndTurn();
            }
        }
        
        public IEnumerator TurnBot()
        {
            yield return new WaitForSeconds(1f); 
            
            // Bot's turn logic goes here
            
            // You can implement AI decision-making, card plays, and other actions

            yield return new WaitForSeconds(1f); 
            
            EndTurn();
        }
        
        public IEnumerator TurnPlayer()
        {
            _boardManager.AddCardToPlayerHand(3); 
             yield return TurnTimer();
            
            if (_activePlayer.ShouldSkipTurn())
            {
                Debug.Log(_activePlayer.playerName + " skipped their turn.");
            }
            else if (_turnTimer <= 0f)
            {
                Debug.Log(_activePlayer.playerName + " ran out of time.");
            }

            yield return new WaitForSeconds(1f); // Delay for visual effect or animation
            EndTurn();
        }

        private IEnumerator TurnTimer()
        {
            while (_turnTimer > 0f && !_activePlayer.ShouldSkipTurn())
            {
                _turnTimer -= Time.deltaTime;
                _nextTurnButton.UpdateTurnTimer(_turnTimer);

                yield return null;
            }
        }

        public void EndTurn()
        {
            _activePlayer.EndTurn();

            if (_activePlayer == humanPlayer)
            {
                if (_playerTurnSkipped || _turnTimer <= 0f)
                    Debug.Log(_activePlayer.playerName + " skipped their turn.");
                _activePlayer = botPlayer;
            }
            else
                _activePlayer = humanPlayer;

            StartTurn();
        }

        /*private IEnumerator DeterminateWinner()
        {
            switch (_activePlayer == humanPlayer)
            {
                case false:
                    yield return _waitAfterEnd;
                    _losePanel.Show();
                    StopCoroutine(_coroutine);
                    break;
                case true when Players.Count == 1:
                    yield return _waitAfterEnd;
                    _winPanel.Show();
                    StopCoroutine(_coroutine);
                    break;
                default:
                    StartTurn();
                    break;
            }
        }*/
    }
}
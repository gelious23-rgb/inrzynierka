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
        public List<Player> Players;
        
        private WinPanel _winPanel;
        private LosePanel _losePanel;
        [SerializeField] private NextTurnButton _nextTurnButton;
        
        private int _activePlayerIndex;
        private readonly WaitForSeconds _waitAfterEnd = new(1f);
        private Coroutine _coroutine;
        private IEnumerator _turnPlayer;

        private void Start()
        {
            _coroutine = StartCoroutine(NextTurn());
        }
        
        private IEnumerator NextTurn()
         {
             for (_activePlayerIndex = 0; _activePlayerIndex < Players.Count ; _activePlayerIndex++)
             {
                 if (Players[_activePlayerIndex].IsPlayer == false)
                     yield return Players[_activePlayerIndex].TurnBot();
                 else
                 {
                     ActivateUI();
                     _turnPlayer = Players[_activePlayerIndex].TurnPlayer(2);
                     yield return new WaitUntil(PlayerEndTurn);
                 }
             }

             StartCoroutine(DeterminateWinner());
         }

        private bool PlayerEndTurn() => _nextTurnButton.gameObject.activeSelf == false || Players.Count == 1;

        private void ActivateUI() => _nextTurnButton.gameObject.SetActive(true);

         private IEnumerator DeterminateWinner()
         {
             switch (Players[0].IsPlayer)
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
                     _coroutine = StartCoroutine(NextTurn());
                     break;
             }
         }
    }
}
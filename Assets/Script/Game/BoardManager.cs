using System.Collections;
using System.Collections.Generic;
using Script.Card;
using UnityEngine;

namespace Script.Game
{
    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private int _playerDeckCardCount;
        [SerializeField] private int _enemyDeckCardCount;
        [SerializeField] private int _playerHandCardLimitCount;
        [SerializeField] private int _enemyHandCardLimitCount;
        [SerializeField] private int _boardCardLimitCount;

        [SerializeField] private GameObject _canvas;

        [SerializeField] private GameObject _playerHand;
        [SerializeField] private GameObject _playerBoard;
        [SerializeField] private GameObject _enemyHand;
        public GameObject EnemyHand()
        {
            return _enemyHand;
        }
        public GameObject EnemyBoard()
        {
            return _enemyBoard;
        }
        [SerializeField] private GameObject _enemyBoard;


        [SerializeField] private Transform _cardInstanceTransform;
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private List<Card.Card> _cards = new List<Card.Card>();
        [SerializeField] private List<GameObject> _playerDeck;
        [SerializeField] private List<GameObject> _enemyDeck;

        void Start()
        {
            InitializePlayerDeck();
            InitializeEnemyDeck();

        }


        public void AddCardToPlayerHand(int p_count)
        {
            if (_playerHand.transform.childCount + p_count > _playerHandCardLimitCount)
            {
                for (int i = _playerHand.transform.childCount; i < _playerHandCardLimitCount; i++)
                {
                    GameObject card = _playerDeck[0];

                    _playerDeck.Remove(_playerDeck[0]);

                    //card.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);

                    card.transform.SetParent(_playerHand.transform);
                }
            }
            else
            {
                for (int i = 0; i < p_count; i++)
                {
                    GameObject card = _playerDeck[0];

                    _playerDeck.Remove(_playerDeck[0]);

                    //card.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);

                    card.transform.SetParent(_playerHand.transform);

                }
            }
            
        }

        public void AddCardToEnemyHand(int p_count)
        {
            if (_enemyHand.transform.childCount + p_count > _enemyHandCardLimitCount)
            {
                for (int i = _enemyHand.transform.childCount; i < _enemyHandCardLimitCount; i++)
                {
                    GameObject card = _enemyDeck[0];

                    _enemyDeck.Remove(_enemyDeck[0]);

                    //card.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);

                    card.transform.SetParent(_enemyHand.transform);
                }
            }
            else
            {
                for (int i = 0; i < p_count; i++)
                {
                    GameObject card = _enemyDeck[0];

                    _enemyDeck.Remove(_enemyDeck[0]);

                    //card.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);

                    card.transform.SetParent(_enemyHand.transform);

                }
            }

        }

        public void InitializePlayerDeck()
        {
            for (int i = 0; i < _playerDeckCardCount; i++)
            {
                _playerDeck.Add(CreateRandomCard());
            }
        }

        public void InitializeEnemyDeck()
        {
            for (int i = 0; i < _enemyDeckCardCount; i++)
            {
                _enemyDeck.Add(CreateRandomCard());
            }
        }

        private GameObject CreateRandomCard()
        {
            // Instantiate blank card with CardDisplay
            GameObject cardInstance = Instantiate(_cardPrefab, _cardInstanceTransform);
            //Assign scriptableObject (random cardinfo)
            cardInstance.GetComponent<CardDisplay>()._card = _cards[Random.Range(0, _cards.Count)];

            CardDragAndDrop cardDragDrop = cardInstance.AddComponent<CardDragAndDrop>();

            cardDragDrop.Initialize(_playerHand, _playerBoard, _canvas, _boardCardLimitCount);

            return cardInstance;
        }
    }
}

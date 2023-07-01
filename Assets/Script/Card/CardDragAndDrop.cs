using Script.Characters;
using Script.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Card
{
    public class CardDragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler 
    {
        private Canvas _canvas;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private Vector3 _originalPosition;
        private GameObject _playerHand;
        private GameObject _playerBoard;
        private GameObject _gameScene;
        private Transform _currentParent;
        private int _boardCardLimitCount;
        private BoardManager _boardManager;
        private Mana.Mana _mana;
        private int _cardDataManacost;


        public void Initialize(GameObject hand, GameObject board, GameObject scene, int boardCardLimit, Player player,
            Mana.Mana mana, int cardDataManacost)
        {
            _playerHand = hand;
            _playerBoard = board;
            _gameScene = scene;
            _boardCardLimitCount = boardCardLimit;
            _canvas = GetComponentInParent<Canvas>();
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _mana = mana;
            _cardDataManacost = cardDataManacost;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _currentParent = _rectTransform.parent;
            _rectTransform.SetParent(_gameScene.transform);

            _canvasGroup.blocksRaycasts = false;

            _originalPosition = _rectTransform.position;
            

    
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {   
                
            Debug.Log("Drag ended over: " + eventData.pointerEnter);

            // IF CARD IS DROPPED ON THE PLAYER BOARD FROM PLAYER HAND
            if (eventData.pointerEnter != null && eventData.pointerEnter.transform == _playerBoard.transform && _currentParent.transform == _playerHand.transform)
            {
                if (_playerBoard.transform.childCount < _boardCardLimitCount && _mana.ManaCurrent >= _cardDataManacost)
                {               
                    // Make the card a child of the board
                    _rectTransform.SetParent(_playerBoard.transform);
                    _mana.Decrease(_cardDataManacost);
                }
                else
                {
                    Debug.Log("Board is Full");
                    _rectTransform.position = _originalPosition;
                    _rectTransform.SetParent(_currentParent.transform);
                }
            }
            else 
                //FROM PLAYER BOARD U CANT MOVE CARD
            if (eventData.pointerEnter != null && _currentParent.transform == _playerBoard.transform)
            {
                _rectTransform.position = _originalPosition;
                _rectTransform.SetParent(_currentParent.transform);
            }
            else
            {
                _rectTransform.position = _originalPosition;
                _rectTransform.SetParent(_playerHand.transform);

            }
            _canvasGroup.blocksRaycasts = true;
        }



        
    }
}
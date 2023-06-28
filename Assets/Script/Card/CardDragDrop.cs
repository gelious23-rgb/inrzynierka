using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 _originalPosition;
    private GameObject _playerHand;
    private GameObject _playerBoard;
    private GameObject _gameScene;
    private Transform _currentParent;
    private int _boardCardLimitCount;

    public void Initialize(GameObject hand, GameObject board , GameObject scene , int boardCardLimit)
    {
        _playerHand = hand;
        _playerBoard = board;
        _gameScene = scene;
        _boardCardLimitCount = boardCardLimit;
        _canvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _currentParent = _rectTransform.parent;

        _rectTransform.SetParent(_gameScene.transform);

        canvasGroup.blocksRaycasts = false;

        _originalPosition = _rectTransform.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the card with the pointer
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("Drag ended over: " + eventData.pointerEnter);

        // IF CARD IS DROPPED ON THE PLAYER BOARD FROM PLAYER HAND
        if (eventData.pointerEnter != null && eventData.pointerEnter.transform == _playerBoard.transform && _currentParent.transform == _playerHand.transform)
        {
            if(_playerBoard.transform.childCount < _boardCardLimitCount)
            {
                // Make the card a child of the board
                _rectTransform.SetParent(_playerBoard.transform);
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
            // If the card is not dropped on the board, return it to the original position and turn on the parent object (hand)
            _rectTransform.position = _originalPosition;
            _rectTransform.SetParent(_playerHand.transform);

        }

        canvasGroup.blocksRaycasts = true;
    }
}
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

    public void Initialize(GameObject hand, GameObject board , GameObject scene)
    {
        _playerHand = hand;
        _playerBoard = board;
        _gameScene = scene;
        _canvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

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

        // Check if the card is dropped on the board
        if (eventData.pointerEnter != null && eventData.pointerEnter.transform == _playerBoard.transform)
        {
            // Make the card a child of the board
            _rectTransform.SetParent(_playerBoard.transform);
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
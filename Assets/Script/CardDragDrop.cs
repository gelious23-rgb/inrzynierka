using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;
    private GameObject playerHand;
    private GameObject playerBoard;
    private GameObject gameScene;

    public void Initialize(GameObject hand, GameObject board , GameObject scene)
    {
        playerHand = hand;
        playerBoard = board;
        gameScene = scene;
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        rectTransform.SetParent(gameScene.transform);

        canvasGroup.blocksRaycasts = false;

        originalPosition = rectTransform.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the card with the pointer
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("Drag ended over: " + eventData.pointerEnter);

        // Check if the card is dropped on the board
        if (eventData.pointerEnter != null && eventData.pointerEnter.transform == playerBoard.transform)
        {
            // Make the card a child of the board
            rectTransform.SetParent(playerBoard.transform);
        }
        else
        {
            // If the card is not dropped on the board, return it to the original position and turn on the parent object (hand)
            rectTransform.position = originalPosition;
            rectTransform.SetParent(playerHand.transform);

        }

        canvasGroup.blocksRaycasts = true;
    }
}
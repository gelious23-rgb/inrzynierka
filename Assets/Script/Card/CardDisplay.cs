using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    public Card _card;
    [SerializeField]
    private TextMeshProUGUI _cardName;
    [SerializeField]
    private TextMeshProUGUI _cardDescription;
    [SerializeField]
    private TextMeshProUGUI _cardHP;
    [SerializeField]
    private TextMeshProUGUI _cardAttack;
    [SerializeField]
    private TextMeshProUGUI _cardManacost;
    [SerializeField]
    private TextMeshProUGUI _cardType;
    [SerializeField]
    private Image _cardImage;

    private Vector3 _originalScale;
    private bool _isHovering;
    private bool _isSelected;
    private Vector3 _offset;


    void Start()
    {
        CardInitialize();
    }

    private void CardInitialize()
    {
        _cardName.text = _card.name;
        _cardDescription.text = _card.description;
        _cardType.text = _card.CardType.ToString();

        _cardAttack.text = _card.attack.ToString();
        _cardManacost.text = _card.manacost.ToString();
        _cardHP.text = _card.hp.ToString();

        _cardImage.sprite = _card.cardImage;
        _cardImage.color = new Color32(255, 255, 255, 255);

        _originalScale = transform.localScale;

    }

    private void Update()
    {
        if (_isHovering)
        {
            // Implement hover behavior (e.g., change scale, color, outline)
            transform.localScale = _originalScale * 1.2f;
        }
        else
        {
            transform.localScale = _originalScale;
        }

        if (_isSelected)
        {
            // Implement dragging behavior
            Vector3 mousePosition = Input.mousePosition;
            transform.position = mousePosition + _offset;
        }
    }

    private void OnMouseEnter()
    {
        _isHovering = true;
    }

    private void OnMouseExit()
    {
        _isHovering = false;
    }

    private void OnMouseDown()
    {
        _isSelected = true;
        _offset = transform.position - Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _isSelected = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    private Card _card;
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
    private Sprite _cardImage;


    void Start()
    {
        CardInitialize();
    }

    private void CardInitialize()
    {
        _cardName.text = _card.name;
        _cardDescription.text = _card.description;
        _cardType.text = _card.cardType;

        _cardAttack.text = _card.attack.ToString();
        _cardManacost.text = _card.manacost.ToString();
        _cardHP.text = _card.hp.ToString();

        _cardImage = _card.cardImage;
    }
}

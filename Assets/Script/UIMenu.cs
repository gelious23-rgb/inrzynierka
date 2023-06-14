using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
using UnityEngine.Events;


public class UIMenu : MonoBehaviour
{
    
    
   // [SerializeField] private Button[] yesNo; //всплывающее окно на будущее
    [SerializeField]  private GameObject NowOpened;
    [SerializeField] private GameObject Compendium;
    [SerializeField] private GameObject Content;
    [SerializeField] private GameObject CardUI;
    [SerializeField] private TextMeshProUGUI NameUI;
    [SerializeField] private TextMeshProUGUI DescUI;
    private ScrollRect Scroll;
    private RectTransform Scroll_Content;
   [SerializeField] private List<Card> AllCards = new List<Card>();
    

    void Start()
    {
  
        foreach (var card in AllCards)
        {
            Spawn(card);
        }

        Scroll = Compendium.transform.GetChild(0).GetComponent<ScrollRect>();
        Scroll_Content = Scroll.content; 

    }

    private void Spawn(Card cardSC)
    {
        var card = Instantiate(CardUI, Content.transform);
        
        List<Transform> Fields = new List<Transform>(); 
        Fields.Add(card.transform.GetChild(0));
        Fields.Add(card.transform.GetChild(1));
        Fields.Add(AddCompendiumCardFieldSecondary(card, 2));
        Fields.Add(AddCompendiumCardFieldSecondary(card, 3));
        Fields.Add(AddCompendiumCardFieldSecondary(card, 4));
        Fields.Add(AddCompendiumCardFieldSecondary(card, 5));
        Fields.Add(AddCompendiumCardFieldSecondary(card, 6));
        Fields[0].GetComponent<TextMeshProUGUI>().text = cardSC.name; 
        Fields[1].GetComponent<TextMeshProUGUI>().text = UtilitySC.DrawDetails(cardSC.description); 
        Fields[2].GetComponent<Image>().sprite = cardSC.cardImage;
        Fields[3].GetComponent<TextMeshProUGUI>().text = cardSC.CardType.ToString(); 
        Fields[4].GetComponent<TextMeshProUGUI>().text = cardSC.hp.ToString(); 
        Fields[5].GetComponent<TextMeshProUGUI>().text = cardSC.attack.ToString();
        Fields[6].GetComponent<TextMeshProUGUI>().text = cardSC.manacost.ToString(); 
        card.GetComponent<Button>().onClick.AddListener(()=>OnClickCard(card));
    }

    private void OnClickCard(GameObject this_)
    {
        NameUI.text = this_.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        DescUI.text = this_.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        for (var index = 0; index < UtilitySC.Keywords.Length; index++)
        {
            var Keyword = UtilitySC.Keywords[index];
            if (DescUI.text.Contains(Keyword))
            {
                DescUI.text = DescUI.text.Replace(DescUI.text, DescUI.text + "\n " + Keyword +
                                                               " - " + UtilitySC.Explanation[index]+ "\n");
            }
        }
        DescUI.text = UtilitySC.DrawDetails(DescUI.text);
        
    }

    private Transform AddCompendiumCardFieldSecondary(GameObject card, int i)
    {
      return  card.transform.GetChild(i).GetChild(0);
    }

   
    
    
    
 public  void Open(GameObject what)
    {
        Close(NowOpened);
        NowOpened = what;
        what.SetActive(true);
    }

    public void Close(GameObject _this)
    {
        if (_this == null)
        {
            return;
        }
        _this.SetActive(false);
        _this = null;
    }
    public void ActExitGame()
    {
        Application.Quit();
    }
    
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
          Close(NowOpened);
       }

       

    }
}

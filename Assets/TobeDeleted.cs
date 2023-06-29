using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobeDeleted : MonoBehaviour
{
    [SerializeField] private List<Card> descriptions = new List<Card>();

    private void Awake()
    {
        dostuff(); //just in case
    }

    [ContextMenu("dostuff")]
     public void dostuff()
    {
        Debug.Log("dostuff invoked");
        foreach (var card in descriptions)
        {

            card.description = card.description.Replace("Powers", "<color=red>Powers</color>")
                .Replace("Man", "<color=blue>Man</color>")
                .Replace("Heroic", "<color=purple>Heroic</color>")
                .Replace("Relic", "<color=yellow>Relic</color>")
                .Replace("Tool", "<color=grey>Tool</color>")
                .Replace("Execution", "<i>Execution</i>")
                .Replace("Burn", "<i>Burn</i>")
                .Replace("Bleed", "<i>Bleed</i>")
                .Replace("Atk down", "<b>Atk down</b>")
                .Replace("Hp down", "<b>Hp down</b>")
                .Replace("Blaze", "<i>Blaze</i>")
                .Replace("Miracle", "<i>Miracle</i>")
                .Replace("Elixir", "<i>Elixir</i>")
                .Replace("Blessings", "<i>Blessings</i>")
                .Replace("Transmutation", "<i>Transmutation </i>")
                .Replace("Curse", "<i>Curse</i>")
                .Replace("Wine", "<i>Wine</i>")
                .Replace("Gluttony", "<i>Gluttony</i>")
                .Replace("Wrath", "<i>Wrath</i>")
                .Replace("Pride", "<i>Pride</i>")
                .Replace("Temperance", "<i>Temperance</i>")
                .Replace("Indignation", "<i>Indignation</i>")
                .Replace("Counterattack", "<i><b>Counterattack</b></i>")
                .Replace("Protection", "<i><b>Protection</b></i>");

        }
    }
}

    


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilitySC 
{
    public static string DrawDetails(string text)
    {
        text = text.Replace("Powers", "<color=red>Powers</color>")
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
        
        
        return text; 
    }

    public static string[] Keywords = new []
    {
        "Execution", "Burn","Bleed", "Atk down", "Hp down","Blaze",
        "Miracle","Elixir","Blessings","Transmutation","Curse", 
        "Wine","Gluttony","Wrath","Pride","Temperance","Indignation","Counterattack","Protection"
    };

    public static string[] Explanation = new[]
    {
        "If target has 50% hp or less, it is instantly destroyed",
        "Stackable, deals 1 dmg per stack at the end of turn",
        "Stackable, when afflicted card attacks, deal 1 damage per stack. Disappears at the end of a turn",
        "Can not be stacked, only strongest value applies. Reduces max Atk by effect value, at the end of the turn return to normal values",
        "Can not be stacked, only strongest value applies. Reduces max Hp by effect value, Hp is restored by the reduced value  at the end of the turn if target is alive",
        "apply burn when hit and on attack",
        "upon receiving lethal damage, do not die and restore hp to max once",
        "restore all hp to max at the end of a turn",
        "receive +Effect value Atk and|or Hp at the end of a turn", 
        "swap Hp and Atk values", 
        "target is transformed into a “pillar of salt” \n Pillar of salt – tool, 12hp 0 atk, when killed, restores 7 hp to a player that killed it",
        "while the creature with this effect is alive, ally cards on the left and right receive +1 atk. When it dies, they restore 3 hp",
        "receive +1 atk per 2 hp restored. Overheal counts",
        "after being hit, gain atk equal to effect value", 
        "“protection” is equal to atk instead of half atk if the attacker has less attack", 
        "block X damage once", 
        "Can attack twice in one turn",
        "After being attacked, attack in retaliation",
        "Reduce incoming damage by half of the own Atk"
         
    };
}

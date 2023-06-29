using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class UtilitySC : MonoBehaviour
{
   [SerializeField] private DescExplanations  DandEx;
    [ContextMenu("S")]
    private void S()
    {
        Debug.Log("displaced");
        DandEx.Descs = Keywords;
        DandEx.Explanations = Explanation;
    }

    public  string[] Keywords = new []
    {
        "Execution", "Burn","Bleed", "Atk down", "Hp down","Blaze",
        "Miracle","Elixir","Blessings","Transmutation","Curse", 
        "Wine","Gluttony","Wrath","Pride","Temperance","Indignation","Counterattack","Protection"
    };

    public  string[] Explanation = new[]
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

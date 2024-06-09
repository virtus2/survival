using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    
    public int itemID;
    public string itemName = "Items/NewItem";
    [TextArea]
    public string itemDescription = "Items/NewItemDesc";
    public Sprite itemSprite;
    public List<PassiveAbility> passive;
    public List<ActiveAbility> active;
    public void ApplyPassive(Player player)
    {
        for(int i=0; i<passive.Count; ++i)
        {
            passive[i].ApplyAbility(player);
        }
    }

    public void UseActive(Player player)
    {
        for (int i = 0; i < active.Count; ++i)
        {
            active[i].UseAbility(player);
        }
    }
}


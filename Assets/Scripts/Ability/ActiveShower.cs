using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Active Shower")]
public class ActiveShower : ActiveAbility
{
    public string sName;
    public override void UseAbility(Player player, GameObject target)
    {
        player.showerSystem.UseAbility(target, sName);
    }


}

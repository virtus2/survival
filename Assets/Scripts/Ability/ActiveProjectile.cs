using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Active Projectile")]
public class ActiveProjectile: ActiveAbility
{
    public string pName;

    public override void UseAbility(Player player, GameObject target)
    {
        player.shotSystem.ShotProjectile(pName, target);
    }
}

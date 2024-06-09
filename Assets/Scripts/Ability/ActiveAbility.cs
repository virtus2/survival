using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : ScriptableObject
{
    public float cooldown;
    public virtual void UseAbility(Player player) { }
    public virtual void UseAbility(Player player, GameObject target) { }

}

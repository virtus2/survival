using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveAbility : ScriptableObject
{
    public abstract void ApplyAbility(Player player);
}

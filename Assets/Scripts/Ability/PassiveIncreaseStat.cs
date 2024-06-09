using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Passive Increase Stat")]
public class PassiveIncreaseStat: PassiveAbility
{
    [Serializable]
    public struct Stat
    {
        public string name;
        public float value;
    }
    [Header("증가시킬 스탯(Player 클래스의 필드명과 같아야함)")]
    public List<Stat> stats;
    public override void ApplyAbility(Player player)
    {
        for(int i=0; i<stats.Count; ++i)
        {
            var field = player.GetType().GetField(stats[i].name);
            float origin = (float)field.GetValue(player);
            float newValue = origin + stats[i].value;
            field.SetValue(player, newValue);
        }
    }
}

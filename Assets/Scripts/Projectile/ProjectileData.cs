using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Projectiles" , fileName = "New Projectile Data")]
public class ProjectileData : ScriptableObject
{
    public Player.Element element;
    public string pName;
    public int preInstanceAmount;
    public float moveSpeed;
}

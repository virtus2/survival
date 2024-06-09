using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public int monsterID;
    public string monsterName;
    public Sprite monsterSprite;
    public float maxHP = 5f;
    public float currentHP = 5f;
    public float damage = 1f;
    public float moveSpeed = 2f;
    public float currentMoveSpeed = 2f;

    public float attackSpeed = 1f;
    public float attackCooldown = 1f;
    public float attackRange = 0.5f;
    public float attackAreaDistance = 1f;
    public bool canAttack;


    public GameObject healthBar;
    protected float distance; // distance between monster and player
    public Player player;
    public Animator animator;
    public Rigidbody2D rb;

    public MonsterMovement moveSystem;

    protected void OnEnable()
    {
        StartCoroutine(AttackCooldown());
    }
    protected bool isTargetInRange()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual IEnumerator AttackCooldown()
    {
        while (true)
        {
            yield return null;
            if (!canAttack) 
            {
                attackCooldown -= Time.deltaTime;
                if(attackCooldown <= 0)
                {
                    attackCooldown = attackSpeed;
                    canAttack = true;
                }
            }
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if(currentHP <= 0)
        {

            Lean.Pool.LeanPool.Despawn(this, 1.5f);
        }
    }
}

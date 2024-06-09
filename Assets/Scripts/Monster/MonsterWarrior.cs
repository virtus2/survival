using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWarrior : MonsterMelee
{

    void Start()
    {
        base.Start();
        attackCooldown = attackSpeed;

        //StartCoroutine(ResetAttackAreaCollider());
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    protected override void InitMonster()
    {

    }

    protected override void AttackEffect()
    {
        //Instantiate();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Potato"))
        {
            // TEST
        }
    }
}

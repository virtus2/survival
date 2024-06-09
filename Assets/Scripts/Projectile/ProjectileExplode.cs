using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplode : ProjectileAbility
{
    // TODO: 폭발이펙트추가
    public GameObject explodeEffect;
    public float range;
    public float damage;
    public override void UseAbility()
    {
        // 범위 안의 몬스터들 구함
        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, range);
        Monster m = null;
        if(monsters != null)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                m = monsters[i].GetComponent<Monster>();
                if (m != null)
                {
                    // TODO: 속성데미지로 바꾸기
                    Debug.Log(damage + "만큼 데미지 범위에 줌");
                    m.TakeDamage(damage);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, range);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float maxHP = 5f;
    public float currentHp = 5f;
    public float damage = 1f;
    public float moveSpeed = 2f;
    public float currentMoveSpeed = 2f;
    public float exp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Despawn();
        }
    }

    public void Despawn()
    {
        if(gameObject.activeSelf)
        {

            Lean.Pool.LeanPool.Despawn(this);
        }
    }
}

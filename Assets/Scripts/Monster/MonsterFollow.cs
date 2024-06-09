using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    public Monster monster;

    public Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 movement;

    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        direction = target.transform.position - transform.position;
        movement = direction.normalized;
        rb.MovePosition(rb.position + movement * monster.currentMoveSpeed * Time.fixedDeltaTime);
    }
    public void MoveTo(GameObject target)
    {
        direction = target.transform.position - transform.position;
        movement = direction.normalized;
        rb.MovePosition(rb.position + movement * monster.currentMoveSpeed * Time.fixedDeltaTime);
    }
}

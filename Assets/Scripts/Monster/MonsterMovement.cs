using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public MonsterBase monsterBase;

    private Vector2 direction;
    private Vector2 movement;

    public void MoveTo(GameObject target)
    {
        direction = target.transform.position - transform.position;
        movement = direction.normalized;
        monsterBase.rb.MovePosition(monsterBase.rb.position + movement * monsterBase.moveSpeed * Time.fixedDeltaTime);
    }
}

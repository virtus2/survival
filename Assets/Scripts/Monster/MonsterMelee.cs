using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : MonsterBase
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        AttackReady,
    };

    public GameObject attackAreaCollider;
    public State currentState = State.Idle;
    WaitForSeconds delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds delay250 = new WaitForSeconds(0.25f);
    // Start is called before the first frame update

    protected void Start()
    {
        //StartCoroutine(FSM());
    }

    protected void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(FSM());
    }
    protected virtual void InitMonster() { }
    protected virtual void AttackEffect() { }
    protected virtual IEnumerator FSM()
    {
        yield return null;
        InitMonster();
        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    protected virtual IEnumerator Idle()
    {
        yield return null;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("Idle");
        }
        
        if (isTargetInRange())
        {
            if (canAttack)
            {
                currentState = State.AttackReady;
            }
            else
            {
                currentState = State.Idle;
            }
        }
        else
        {
            currentState = State.Move;
        }
    }
    protected virtual IEnumerator AttackReady()
    {
        yield return null;
        //animator.SetTrigger("AttackReady");
        currentMoveSpeed = 0f;
        yield return delay500;
        currentState = State.Attack;
    }
    protected virtual IEnumerator Attack()
    {
        yield return null;
        if(Vector2.Distance(player.transform.position, this.transform.position) <= attackRange)
        {
            player.TakeDamage(1f);
        }
        //animator.SetTrigger("Attack");
             // 플레이어가 범위안에 있을경우 데미지를 입히는 걸 만들어야하는데
            //판정을 SetActive 켰다껐다ㅎ하는지
            // 판정은 계속 켜두되 공격때만 플레이어가 공격받는지를 불러와야 하는지
            // 이럴경우에 다른몬스터들이 한번에 공격할땐 어떻게 되는지
            // 
        yield return delay250;
        currentMoveSpeed = moveSpeed;
        canAttack = false;
        currentState = State.Idle;
    }
    protected virtual IEnumerator Move()
    {
        yield return null;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("move"))
        {
            //animator.SetTrigger("move");
        }
        if(isTargetInRange() && canAttack)
        {
            currentState = State.AttackReady;
        }
        else
        {
            moveSystem.MoveTo(player.gameObject);
        }
    }
}

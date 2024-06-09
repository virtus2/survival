using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 발사체 속성
    public enum Element
    {
        Normal,
        Fire,
        Water,
        Chaos,
        COUNT
    }
    [SerializeField] private Joystick joystick;

    public float maxHP;
    public float currentHP;
    public float moveSpeed = 1f;
    public float shotSpeed = 2.5f;
    public float damage;
    public int penetrate;

    public List<Item> ownItem;
    // 발사체 속성 데미지 배율 담을 리스트
    public List<float> element;

    public PlayerMovement moveSystem;
    public PlayerShot shotSystem;
    public PlayerShower showerSystem;
    public PlayerActive activeSystem;
    public MonsterManager monsterManager;

    private bool attackedByMonster;


    public void Initialize()
    {
        ownItem = new List<Item>(15);
        element = new List<float>((int)Element.COUNT);
        for(int i=0; i<(int)Element.COUNT; i++)
        {
            element.Add(1f);
        }
    }


    public void EnterDungeon()
    {
        Initialize();
        activeSystem.Init();
        monsterManager.StartFindMonster();
    }


    public void AddItem(Item item)
    {
        // 아이템 획득했을때 패시브 적용
        item.ApplyPassive(this);
        // 액티브 아이템 일경우
        if(item.active.Count > 0)
        {
            // 액티브 스킬 시스템에 넘겨줌
            activeSystem.AddAbility(item);
        }
        // 획득한 아이템 목록에 추가
        ownItem.Add(item);
    }

    public void DamageTo(Monster monster, Projectile projectile)
    {
        float dmg = projectile.damage * element[(int)projectile.data.element];
        monster.TakeDamage(dmg);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("아이고아파라");
        if(attackedByMonster)
        {
            currentHP -= damage;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Interactable"))
        {
            joystick.OnInteractStart(collision.gameObject);
        }
        else if (collision.transform.CompareTag("Item"))
        {
            GameManager.Instance.ChoiceSupply();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            joystick.OnInteractEnd();
        }

    }

}

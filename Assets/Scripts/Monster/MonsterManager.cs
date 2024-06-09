using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public MonsterSpawner monsterSpawner;
    private GameObject closestMonster;
    public Player player;
    WaitForSeconds delay50 = new WaitForSeconds(0.05f);
    public void StartFindMonster()
    {
        StartCoroutine(FindClosestMonsterCoroutine());

    }

    public IEnumerator FindClosestMonsterCoroutine()
    {
        while (true)
        {
            if(closestMonster == null || closestMonster.activeSelf == false)
            {
                FindClosestMonster();
            }
            else
            {
                yield return delay50;
            }
            yield return null;
        }
    }
    public GameObject GetClosestMonster()
    {
        if (closestMonster == null || closestMonster.activeSelf == false) return null;
        return closestMonster;
    }

    public void FindClosestMonster()
    {
        Monster[] monsters = GetComponentsInChildren<Monster>();
        GameObject obj = null;
        float distance;
        float minimum = 100000f;
        for(int i=0; i < monsters.Length; ++i)
        {
            distance = Vector2.Distance(monsters[i].transform.position, player.transform.position);
            if(minimum > distance)
            {
                minimum = distance;
                obj = monsters[i].gameObject;
            }
        }
        if (obj == null) return;
        
        if (Mathf.Abs(obj.transform.position.x - player.transform.position.x) < 5.5f
            && Mathf.Abs(obj.transform.position.y - player.transform.position.y) < 10f)
        {
            closestMonster = obj;
        }
        else
        {
            closestMonster = null;
        }
    }

    public GameObject GetRandomMonster(Player player)
    {
        GameObject obj = null;

        return obj;
    }

}

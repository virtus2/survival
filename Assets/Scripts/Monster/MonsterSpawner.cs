using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>(8);

    public Player player;
    public List<Monster> prefabList;
    public Monster monsterPrefab;
    public MonsterManager monsterManager;

    public float hpMulti;

    private float currentSeconds = 0f;
    public float spawnSeconds= 1.5f;
    public float spawnAmount;

    private Vector2 spawnPosition;
    private float distance;

    private void Update()
    {
        currentSeconds += Time.deltaTime;
        if(currentSeconds > spawnSeconds)
        {
            int rnd = Random.Range(0, spawnPoints.Count);
            for(int i=0; i<spawnAmount; ++i)
            {
                spawnPosition = spawnPoints[rnd].transform.position + Random.onUnitSphere * 0.5f;
                SpawnMonster(spawnPosition);
            }
            currentSeconds = 0f;
        }
    }
    public void SpawnMonster(Vector2 position)
    {
        
        Monster m = Lean.Pool.LeanPool.Spawn(monsterPrefab, position, new Quaternion(0, 0, 0, 0), monsterManager.transform);
        // 몬스터 이동의 대상을 플레이어로 설정
        // Fix: 플레이어도 프리팹으로 생성하면 몬스터 프리팹에서 직접 지정가능
        m.GetComponent<MonsterFollow>().SetTarget(player.gameObject);
        
        m.currentHp = m.maxHP;
    }

    public void SpawnMonster(string name, Vector2 position)
    {

    }


}

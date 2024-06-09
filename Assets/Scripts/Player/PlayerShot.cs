using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Player player;

    public BulletSpawner bulletSpawner;
    public ProjectileSpawner projectileSpawner;
    public MonsterManager monsterManager;

    private float secondsAfterShot = 0f;
    private bool readyToShot = true;

    private Vector2 target;

    private void Update()
    {
        // 총 발사할 준비 안됐을때
        if(readyToShot == false)
        {
            secondsAfterShot += Time.deltaTime;
            // 발사 속도만큼 발사 후 시간이 흘렀으면
            if(secondsAfterShot >= player.shotSpeed)
            {
                // 발사 준비가 됐다
                readyToShot = true;
                secondsAfterShot = 0f;
            }
        }
        // 총 발사할 준비 됐을때
        else
        {
            GameObject go = monsterManager.GetClosestMonster();
            // 가까운 몬스터가 없다면
            if (go == null || go.activeSelf == false)
            {

            }
            // 가까운 몬스터가 있다면
            else
            {
                // 발사하고 총 발사를 다시 준비시킨다
                
                ShotProjectile("Base", go);
                readyToShot = false;

            }
        }
    }

    public void UpdateClosestMonster()
    {
        
        //closestMonster = monsterManager.FindClosestMonster(player);

    }
    public void Shot(string name)
    {
        //Vector2 direction = closestMonster.transform.position - gameObject.transform.position;
        //bulletSpawner.SpawnBullet(gameObject.transform.position, direction);
    }

    public void ShotProjectile(string name)
    {
        //Vector2 direction = closestMonster.transform.position - gameObject.transform.position;
        //projectileSpawner.SpawnProjectile(name, transform.position, direction);
    }

    public void ShotProjectile(string name, GameObject target)
    {
        Vector2 direction = target.transform.position - gameObject.transform.position;
        projectileSpawner.SpawnProjectile(name, transform.position, direction);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Bullet bulletPrefab;

    private Queue<Bullet> spawnedBullets;
    private int maxBulletsInScreen = 40;
    // Update is called once per frame
    private void Start()
    {
        spawnedBullets = new Queue<Bullet>(30);
    }

    public void SpawnBullet(Vector2 player, Vector2 direction)
    {
        Bullet b = Lean.Pool.LeanPool.Spawn(bulletPrefab, player, new Quaternion(0, 0, 0, 0), transform);
        b.GetComponent<BulletMovement>().SetDirection(direction);
        spawnedBullets.Enqueue(b);

    }

}

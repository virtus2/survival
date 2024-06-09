using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public List<Projectile> projectilePrefab;
    private Dictionary<string, Projectile> projectileDict;
    private Queue<Bullet> spawnedBullets;
    private int maxBulletsInScreen = 40;
    private Quaternion zero = new Quaternion(0, 0, 0, 0);
    // Update is called once per frame
    private void Start()
    {
        spawnedBullets = new Queue<Bullet>(30);
        projectileDict = new Dictionary<string, Projectile>(projectilePrefab.Count);
    }

    public void SpawnProjectile(string name, Vector2 player, Vector2 direction)
    {
        Projectile p = null;
        if (projectileDict.ContainsKey(name))
        {
            p = Lean.Pool.LeanPool.Spawn(projectileDict[name], player, zero, transform);
        }
        else
        {
            for (int i = 0; i < projectilePrefab.Count; ++i)
            {
                if (name.CompareTo(projectilePrefab[i].data.pName) == 0)
                {
                    projectileDict.Add(name, projectilePrefab[i]);
                    p = Lean.Pool.LeanPool.Spawn(projectilePrefab[i], player, zero, transform);
                }
            }
        }
        if (p == null)
        {
            Debug.LogWarning("Projectile Prefab: " + name + " 을 Projectile Spawner에 등록해야함");
        }
        else
        {
            p.ResetPenetrate();
            p.SetDirection(direction);
        }
    }
}

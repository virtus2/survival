using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData data;
    public Rigidbody2D rb;
    private int currentPenetrate = 1;
    public int penetrate = 1;
    public float damage = 1;
    public ProjectileAbility ability;
    private Vector2 direction;
    private Vector2 movement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            if (currentPenetrate > 0)
            {
                currentPenetrate--;
                GameManager.Instance.GetDungeonPlayer().DamageTo(collision.GetComponent<Monster>(), this);
                if (ability != null)
                {
                    ability.UseAbility();
                }
            }
            if (currentPenetrate <= 0)
            {
                if (this.gameObject.activeSelf)
                {
                    Lean.Pool.LeanPool.Despawn(this);
                }
            }
        }
    }

    public void ResetPenetrate()
    {
        currentPenetrate = penetrate;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
        movement = direction.normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * data.moveSpeed * Time.fixedDeltaTime);
    }
}

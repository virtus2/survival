using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public Joystick joyStick;

    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joyStick.Horizontal;
        movement.y = joyStick.Vertical;
        animator.SetFloat("Horizontal", movement.x);
    }
    private void FixedUpdate()
    {
        float mag = Mathf.Clamp01(new Vector2(joyStick.Horizontal, joyStick.Vertical).magnitude);
        rb.MovePosition(rb.position + movement * mag * player.moveSpeed * Time.fixedDeltaTime);
    }

}

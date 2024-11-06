using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 moveInput;
    PlayerStats stats;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (moveInput != Vector2.zero)
        {
            anim.SetFloat("movementX", moveInput.x);
            anim.SetFloat("movementY", moveInput.y);
            anim.SetBool("isMoving", true);
        }
        else
        {

            anim.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate()
    {
        float spdMultiplier = 1 + (stats.speed / 10);
        rb.velocity = moveInput.normalized * moveSpeed * spdMultiplier;
    }
}

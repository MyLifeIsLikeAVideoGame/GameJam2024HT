using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, slowSpeed;
  [HideInInspector]public  float speed;
    Rigidbody2D rb;
    Vector2 moveInput;
    PlayerStats stats;
    Animator anim;

    public KeyCode gunEquipButton;
    bool equipping = false;
    public Gun gun;
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
        if (equipping)
        {
            speed = slowSpeed;
            gun.canShoot = true;
        }
        else
        {
            speed = moveSpeed;
            gun.canShoot = false;
        }

        if (Input.GetKeyDown(gunEquipButton))
        {
            EquipAndUnequip();
        }
        anim.SetBool("hasGun", equipping);
    }

    private void FixedUpdate()
    {
        float spdMultiplier = 1 + (stats.speed / 10);
        rb.velocity = moveInput.normalized * speed * spdMultiplier;
    }

    void EquipAndUnequip()
    {
        equipping = !equipping;
    }
}

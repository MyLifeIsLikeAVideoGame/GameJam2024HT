using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBossSpear : MonoBehaviour
{
    public float waitTime;
    Rigidbody2D rb;
    public Vector2 vel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("SetVelocity", waitTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Entity>().TakeDamage(1);
            Destroy(this);
        }
    }

    public void SetVelocity()
    {
        rb.velocity = vel;
    }
}

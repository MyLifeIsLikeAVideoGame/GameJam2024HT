using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBossSpear : MonoBehaviour
{
    public float waitTime;
    Rigidbody2D rb;
    public Vector2 vel, squareSize;
    public LayerMask whatIsSolid;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("SetVelocity", waitTime);

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] touching = Physics2D.OverlapBoxAll(transform.position, squareSize, transform.rotation.z, whatIsSolid);
        if (touching != null)
        {
            foreach (Collider2D t in touching)
            {
                if (t.GetComponent<Entity>() != null)
                {
                    t.GetComponent<Entity>().TakeDamage(1);
                    Destroy(gameObject);
                }
            }
        }
    }
    public void SetVelocity()
    {
        rb.velocity = vel;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, squareSize);
    }
}

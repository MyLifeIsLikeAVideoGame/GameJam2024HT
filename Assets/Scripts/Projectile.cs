using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float size;
    public LayerMask whatIsSolid;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] touchingSolid = Physics2D.OverlapCircleAll(transform.position, size, whatIsSolid);
        foreach (Collider2D t in touchingSolid)
        {
            if (t != null)
            {
                if (t.GetComponent<Entity>() != null)
                {
                    t.GetComponent<Entity>().TakeDamage(damage);
                }
                Destroy(gameObject);
            }
            
        }
           
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
            Gizmos.DrawWireSphere(transform.position,  size);
        
    }
}



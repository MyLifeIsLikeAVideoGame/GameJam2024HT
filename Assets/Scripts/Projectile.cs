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

        RaycastHit2D touchingSolid = Physics2D.Raycast(transform.position, Vector2.up, size, whatIsSolid);     
        if (touchingSolid.collider != null)
        {
            if (touchingSolid.collider.GetComponent<Entity>() != null)
            {
                touchingSolid.collider.GetComponent<Entity>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
            Gizmos.DrawWireCube(transform.position, Vector3.up * size);
        
    }
}



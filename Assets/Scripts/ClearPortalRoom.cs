using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPortalRoom : MonoBehaviour
{
    public Vector2 range;
    public LayerMask whatIsenemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Clear", 1);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void Clear()
    {
        Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, range, 0, whatIsenemy);
        foreach (Collider2D enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, range);
    }
}

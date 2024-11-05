using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomChecker : MonoBehaviour
{
    public GameObject[] locks;
    public List<Collider2D> enemies;
   public bool enemiesDefeated;
    public Vector2 roomSize;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemys = Physics2D.OverlapBoxAll(transform.position, roomSize, 0, enemyLayer);
        enemies = enemys.ToList<Collider2D>();
        if (enemies.Count <= 0)
        {
            Unlock();
        }
    }
   public void Lock()
    {
        foreach (GameObject g in locks)
        {
            g.SetActive(true);
        }
    }
    void Unlock()
    {
        enemiesDefeated = true;
        foreach (GameObject g in locks)
        {
            g.SetActive(false);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, roomSize);
    }
}

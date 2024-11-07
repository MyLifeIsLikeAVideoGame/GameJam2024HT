using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemySpawner : MonoBehaviour
{
    public MapSpriteSelector room;
    public Vector2 minSpawn, maxSpawn;
    public GameObject[] enemies;
    public int minEnemies, maxEnemies;
    int randEnemies;
    // Start is called before the first frame update
    void Start()
    {
         randEnemies = Random.Range(minEnemies, maxEnemies + 1);
        if (room.type != 1)
        {
            SpawnEnemy();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, maxSpawn - minSpawn);
    }
    void SpawnEnemy()
    {
        Vector2 randPos = Vector2.zero;
        int randEnemy = 0;
        for (int i = 0; i < randEnemies; i++)
        {
            randPos = new Vector2( transform.position.x + Random.Range(minSpawn.x, maxSpawn.x),transform.position.y +  Random.Range(minSpawn.y, maxSpawn.y));
            randEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randEnemy], randPos, Quaternion.identity);
        }
    }
}

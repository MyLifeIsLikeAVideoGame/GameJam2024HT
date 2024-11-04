using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayerAI : MonoBehaviour
{
    public float range, moveSpeed;
    public Transform player;
    bool playerDetected;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= range)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;

        }
        if (playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        }

    }
    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

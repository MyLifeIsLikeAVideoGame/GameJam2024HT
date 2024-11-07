using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayerAI : MonoBehaviour
{
    public float range, moveSpeed;
    public Transform player;
    bool playerDetected;
    bool kb, move = true;
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
        if (playerDetected && !kb && move)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        }

        if (kb && !move)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime * 4);

        }

    }
 

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && kb != true)
        {
            collision.collider.GetComponent<PlayerStats>().health--;
            StartCoroutine(kbStart());
        }
    }

    IEnumerator kbStart()
    {
        move = false;
        kb = true;
        yield return new WaitForSeconds(.2f);
        kb = false;
        yield return new WaitForSeconds(.4f);
        move = true;
    }
}

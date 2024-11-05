using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyAI : MonoBehaviour
{
    public float followRange, runAwayRange, moveSpeed;
    public Transform player;

    public float shootCooldown;
    public Transform shotPoint;
    public GameObject bullet;
    float startShootCooldown;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= followRange && Vector2.Distance(transform.position, player.position) > runAwayRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        

        if (Vector2.Distance(transform.position, player.position) <= runAwayRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);

        }

        if (startShootCooldown <= 0)
        {
            Shoot();
            startShootCooldown = shootCooldown;
        }
        else
        {
            startShootCooldown -= Time.deltaTime;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color  = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.DrawWireSphere(transform.position, runAwayRange);
    }

    void Shoot()
    {
      GameObject a =  Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        Rigidbody2D arb = a.GetComponent<Rigidbody2D>();
        Vector2 dir = shotPoint.rotation * Vector2.up;
        arb.velocity = dir * 20;

    }
}

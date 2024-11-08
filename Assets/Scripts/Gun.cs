using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int numberOfbullets;
    public float bulletSpeed, bulletSpread;
    float shootstartcooldown;
    public GameObject bulletPrefab;
    public Transform shootPosition;
    PlayerStats stats;
    public IntValue bulletsSave;
    public FloatValue spreadSave;
    public bool canShoot;
    public GameObject shootSound;
    float tapcooldown, starttapcooldown;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponentInParent<PlayerStats>();
        bulletSpread = spreadSave.value;
        numberOfbullets = bulletsSave.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            if (shootstartcooldown <= 0)
            {
                Shoot();
                shootstartcooldown = stats.fireRate;

            }
            else
            {
                shootstartcooldown -= Time.deltaTime;
            }

        }

        if (shootstartcooldown <= 0)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                Shoot();
                shootstartcooldown = stats.fireRate;

            }

        }
        else
        {
            shootstartcooldown -= Time.deltaTime;

        }

        spreadSave.value = bulletSpread;
        bulletsSave.value = numberOfbullets;
    }

    void Shoot()
    {
        Instantiate(shootSound);
        float dmgMultiplier = 1 + (stats.power/5);
        for (int i = 0; i < numberOfbullets; i++)
        {
            GameObject a = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
           float total =  a.GetComponent<Projectile>().damage * dmgMultiplier;
            a.GetComponent<Projectile>().damage = Mathf.RoundToInt(total);
            Rigidbody2D arb = a.GetComponent<Rigidbody2D>();
            Vector2 dir = shootPosition.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-bulletSpread, bulletSpread);
            arb.velocity = (dir + pdir) * bulletSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBossAI : MonoBehaviour
{
    public bool knifing, shootingSide, shootingTop;
    public Transform[] knifeSpawnPoints, bulletSideSpawnPoints, bulletTopSpawnPoints;
    public GameObject bullet, knife, bulletIndicator, knifeIndicator;

    public float knifeDuration;
    public float shootingSideDuration, shootingTopDuration, shootingSideInterval, shootingTopInterval, bulletSpeed, knifeSpeed;
    float startKnifeDuration, startShootingSideDuration, startShootingTopDuration, startShootingSideInterval, startShootingTopInterval;
    public int amountOfShootSideAtOnce, amountOfShootingTopAtOnce;
    // Start is called before the first frame update
    void Start()
    {
        NewAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (knifing)
        {
           
                knifeStart();
                NewAttack();
            
        }
        if (shootingSide)
        {
            if (shootingSideDuration > 0)
            {
                if (startShootingSideInterval <= 0)
                {
                    ShootSide();
                    startShootingSideInterval = shootingSideInterval;
                }
                else
                {
                    startShootingSideInterval -= Time.deltaTime;
                }
                startShootingSideDuration -= Time.deltaTime;
            }
            else
            {
                shootingSide = false;
                NewAttack();
            }
        }
        if (shootingTop)
        {
            if (startShootingTopDuration > 0)
            {
                if (startShootingTopInterval <= 0)
                {
                    ShootTop();
                    startShootingTopInterval = shootingTopInterval;
                }
                else
                {
                    startShootingTopInterval -= Time.deltaTime;
                }
                startShootingTopDuration -= Time.deltaTime;
            }
            else
            {
                shootingTop = false;
                NewAttack();
            }
        }

    }
    void startKnifing()
    {
        startKnifeDuration = knifeDuration;
        knifing = true;
    }
    void startShootingSide()
    {
        startShootingSideDuration = shootingSideDuration;
        shootingSide = true;
    }
    void startShootingTop()
    {
        startShootingTopDuration = shootingTopDuration;
        shootingTop = true;
    }
    void NewAttack()
    {

        StartCoroutine(WaitForNewAttack());

    }

    IEnumerator WaitForNewAttack()
    {
        int rand = 0;
        rand = Random.Range(1, 4);
        yield return new WaitForSeconds(2f);
        if (rand == 1)
        {
            startKnifing();
        }
        else if (rand == 2)
        {
            startShootingSide();
        }
        else if (rand == 3)
        {
            startShootingTop();
        }
    }

    void knifeStart()
    {
        for (int i = 0; i < knifeSpawnPoints.Length; i++)
        {
           GameObject a = Instantiate(knife, knifeSpawnPoints[i].position, knifeSpawnPoints[i].rotation);
            Instantiate(knifeIndicator, knifeSpawnPoints[i].position, knifeSpawnPoints[i].rotation);
            Vector2 dir = knifeSpawnPoints[i].rotation * Vector2.up;
            a.GetComponent<ShieldBossSpear>().vel = dir * knifeSpeed;


        }
        knifing = false;
    }

    public void ShootSide()
    {
        for (int i = 0; i < amountOfShootSideAtOnce; i++)
        {
            int randPos = Random.Range(0, bulletSideSpawnPoints.Length);
          GameObject a = Instantiate(bullet, bulletSideSpawnPoints[randPos].position, bulletSideSpawnPoints[randPos].rotation);
            Instantiate(bulletIndicator, bulletSideSpawnPoints[randPos].position, bulletSideSpawnPoints[randPos].rotation);
            Vector2 dir = bulletSideSpawnPoints[randPos].rotation * Vector2.up;
            a.GetComponent<ShieldBossSpear>().vel = dir * bulletSpeed;
        }
    } 
    public void ShootTop()
    {
        for (int i = 0; i < amountOfShootingTopAtOnce; i++)
        {
            int randPos = Random.Range(0, bulletTopSpawnPoints.Length);
            GameObject a =  Instantiate(bullet, bulletTopSpawnPoints[randPos].position, bulletTopSpawnPoints[randPos].rotation);
            Instantiate(bulletIndicator, bulletTopSpawnPoints[randPos].position, bulletTopSpawnPoints[randPos].rotation);
            Vector2 dir = bulletTopSpawnPoints[randPos].rotation * Vector2.up;
            a.GetComponent<ShieldBossSpear>().vel = dir * bulletSpeed;
        }
    }

}

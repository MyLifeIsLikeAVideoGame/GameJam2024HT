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
            if (startKnifeDuration > 0)
            {               
                startKnifeDuration -= Time.deltaTime;
            }
            else
            {
                knifing = false;
                NewAttack();
            }
        }
        if (shootingSide)
        {
            if (shootingSideDuration > 0)
            {
                if (startShootingSideInterval <= 0)
                {
                    ThrowSpear();
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
                    Slam();
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

    IEnumerator knife()
    {
        for (int i = 0; i < knifeSpawnPoints.Length; i++)
        {

        }
    }

}

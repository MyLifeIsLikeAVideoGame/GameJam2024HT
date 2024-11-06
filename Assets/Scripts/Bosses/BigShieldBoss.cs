using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShieldBoss : Entity
{
    [Header("References")]
    public Transform[] WeaponSpawnPoints;
    public Transform[] enemySpawnPoints;
    public Transform slamPos;
    bool spawning, throwing, slamming;
    public GameObject SpearProjectile, slamProjectile, spearIndicator, slamIndicator;
    public GameObject[] enemies;
    [Header("Stats")]
    public float spawningDuration;
    public float throwDuration, slamDuration, spawnInterval, throwInterval, spearSpeed, shockSpeed;
    float startThrowDuration, startSlamDuration, startSpawnDuration, startThrowInterval, startSpawnInterval;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            if (startSpawnDuration >  0)
            {
                if (startSpawnInterval <= 0)
                {
                    SpawnEnemy();
                    startSpawnInterval = spawnInterval;
                }
                else
                {
                    startSpawnInterval -= Time.deltaTime;
                }
                startSpawnDuration -= Time.deltaTime;
            }
            else
            {
                spawning = false;
            }
        }
        if (throwing)
        {
            if (startThrowDuration > 0)
            {
                if (startThrowInterval <= 0)
                {
                    ThrowSpear();
                    startThrowInterval = throwInterval;
                }
                else
                {
                    startThrowInterval -= Time.deltaTime;
                }
                startThrowDuration -= Time.deltaTime;
            }
            else
            {
                throwing = false;
            }
        }
        if (slamming)
        {
            Slam();
            slamming = false;   
        }
    }
    void startThrowing()
    {
        startThrowDuration = throwDuration;
        throwing = true;
    }
    void startSlamming()
    {
        startSlamDuration = slamDuration;
        slamming = true;
    }
    void startSpawning()
    {
        startSpawnDuration = spawningDuration;
        spawning = true;
    }
    void NewAttack()
    {
        int rand = 0;
        rand = Random.Range(1, 4);
        StartCoroutine(WaitForNewAttack());
        if (rand == 1)
        {
            startSpawning();
        }
        else if (rand == 2)
        {
            startThrowing();
        }
        else if (rand == 3)
        {
            startSlamming();
        }
    }

    IEnumerator WaitForNewAttack()
    {
        yield return new WaitForSeconds(1f);

    }

    void SpawnEnemy()
    {
        int randEnemy = Random.Range(0, enemies.Length);
        int randPos = Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemies[randEnemy], enemySpawnPoints[randPos].position, Quaternion.identity);
    }
    void Slam()
    {
        Instantiate(slamIndicator, slamPos.position,Quaternion.identity);
        GameObject a = Instantiate(slamProjectile, slamPos.position,slamPos.rotation);
        Vector2 dir = slamPos.rotation * Vector2.up;
        a.GetComponent<ShieldBossSpear>().SetVelocity(dir * shockSpeed);

    }
    void ThrowSpear()
    {
        int randPos = Random.Range(0, WeaponSpawnPoints.Length);
        Instantiate(spearIndicator, WeaponSpawnPoints[randPos].position, WeaponSpawnPoints[randPos].rotation);
       
        GameObject a = Instantiate(SpearProjectile, WeaponSpawnPoints[randPos].position, WeaponSpawnPoints[randPos].rotation);
        Vector2 dir = WeaponSpawnPoints[randPos].rotation * Vector2.up;
        a.GetComponent<ShieldBossSpear>().SetVelocity(dir * spearSpeed);
    }
}

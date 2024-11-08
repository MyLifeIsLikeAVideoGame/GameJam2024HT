using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health;
    public int xpDrop;
    public GameObject[] lootTable;
    public int[] dropChance;

    public Material flashMaterial, normalMaterial;
    public AudioSource deathSound;
    public GameObject deathAudio;
    public AudioSource damageSound;

    private void Start()
    {
        normalMaterial = GetComponent<SpriteRenderer>().material;
    }

    public virtual void TakeDamage(int damage)
    {
        damageSound.Play();
        StartCoroutine("flash");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Instantiate(deathAudio);
        deathSound.Play();
        DropLoot(lootTable);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().currentXp += xpDrop;
        Destroy(gameObject);
    }

    public virtual void DropLoot(GameObject[] possible_loot)
    {
        int lootDropChanceRandomizer;

        for (int i = 0; i < possible_loot.Length; i++)
        {
            lootDropChanceRandomizer = Random.Range(0, 100);

            if (dropChance[i] >= lootDropChanceRandomizer)
            {
                Instantiate(possible_loot[i], transform.position, Quaternion.identity);
            }
        }


        
    }

    public IEnumerator flash()
    {
        GetComponent<SpriteRenderer>().material = flashMaterial;
        yield return new WaitForSeconds(0.06f);
        GetComponent<SpriteRenderer>().material = normalMaterial;
    }
}

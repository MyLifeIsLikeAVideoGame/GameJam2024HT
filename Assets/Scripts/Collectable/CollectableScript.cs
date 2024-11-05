using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public AudioSource collectSound;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public CollectableManager collectableManager;
    public PlayerStats playerStats;

    private void Start()
    {
        collectSound = gameObject.GetComponent<AudioSource>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        CollectOnly(collision);
    }

    public virtual void EffectsOnCollect()
    {
        collectSound.Play();
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;

        if (collectSound.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

    public virtual void AddToManager(Collision2D collision_player)
    {
        collectableManager = collision_player.gameObject.GetComponent<CollectableManager>();
    }

    public virtual void AddToStats(Collision2D collision_player)
    {
        playerStats = collision_player.gameObject.GetComponent<PlayerStats>();
    }

    public void CollectAndAddPoints(Collision2D collision_player)
    {

        if (collision_player.gameObject.tag == "Player")
        {
            EffectsOnCollect();
            AddToManager(collision_player);
        }
    }

    public void CollectAndAddStats(Collision2D collision_player)
    {

        if (collision_player.gameObject.tag == "Player")
        {
            EffectsOnCollect();
            AddToStats(collision_player);
        }
    }

    public void CollectOnly(Collision2D collision_player)
    {
        if (collision_player.gameObject.tag == "Player")
        {
            EffectsOnCollect();
        }
    }
}

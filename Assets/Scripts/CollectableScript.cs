using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public AudioSource collectSound;

    private void Start()
    {
        collectSound = gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectSound.Play();
            Destroy(gameObject);
        }
    }
}

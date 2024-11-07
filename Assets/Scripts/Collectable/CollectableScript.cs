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

    public Transform objTrans;
    public float delay = 0;
    public float pasttime = 0;
    public float when = 1.0f;
    public Vector3 off;

    public Rigidbody2D rig;
    public GameObject player;
    public bool magnetize = false;
    public bool magneticObject = true;

    public virtual void Awake()
    {
        off = new Vector3(Random.Range(-3, 3), off.y, off.z);
        off = new Vector3(off.x, Random.Range(-3, 3), off.z);
    }

    private void Start()
    {
        objTrans = gameObject.GetComponent<Transform>();
        collectSound = gameObject.GetComponent<AudioSource>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
        rig = gameObject.GetComponent<Rigidbody2D>();

        if (magneticObject == true)
        {
            StartCoroutine(Magnet());
        }
        
    }

    public virtual void Update()
    {
        if (when >= delay)
        {
            pasttime = Time.deltaTime;
            objTrans.position += off * Time.deltaTime;
            delay += pasttime;
        }
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

    public virtual void Magnetize(bool activate_magnet)
    {
        if (magnetize == true)
        {
            Vector3 playerPoint = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, -0.3f, 0), 20 * Time.deltaTime);
            rig.MovePosition(playerPoint);
        }
    }

    public IEnumerator Magnet()
    {
        yield return new WaitForSeconds(2f);
        magnetize = true;
    }
}

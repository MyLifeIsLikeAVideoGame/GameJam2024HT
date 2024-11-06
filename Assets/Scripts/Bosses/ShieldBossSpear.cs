using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBossSpear : MonoBehaviour
{
    public float waitTime;
    Rigidbody2D rb;
    public Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("SetVelocity", waitTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVelocity()
    {
        rb.velocity = vel;
    }
}

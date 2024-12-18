using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLockTrigger : MonoBehaviour
{
    public RoomChecker room;
    public Vector2 playerOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && room.enemiesDefeated == false)
        {
            other.transform.position += new Vector3(playerOffset.x , playerOffset.y * 2, 0);
            room.Lock();
            
        }
    }   
}

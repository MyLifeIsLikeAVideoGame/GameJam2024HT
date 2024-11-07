using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : CollectableScript
{
    public override void Awake()
    {
        base.Awake();
        magneticObject = false;
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        CollectAndAddPoints(collision);
    }


    public override void AddToManager(Collision2D collision_player)
    {
        base.AddToManager(collision_player);
        collectableManager.keysCollected += 1;
    }

}

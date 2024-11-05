using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCollectableScript : CollectableScript
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        CollectAndAddStats(collision);
    }


    public override void AddToStats(Collision2D collision_player)
    {
        base.AddToStats(collision_player);
        playerStats.health += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : CollectableScript
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        CollectAndAddPoints(collision);
    }

    public override void AddToManager(Collision2D collision_player)
    {
        base.AddToManager(collision_player);
        collectableManager.pointsCollected += 1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{

    protected override void Collect(Player2 player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.treasureCount++;
        }
    }
}

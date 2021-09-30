/*
 * This script defines how picking up treasure works. 
 * Inventory script is called to add to the count
 */

using System;
using UnityEngine;

public class Treasure : CollectibleBase
{
    public event Action<int> CharacterTreasureCount;
    public event Action<GameObject> ThisGameObject;

    //private GameObject treasure;
    protected override void Collect(PlayerHealth player)
    {
        Debug.Log("Collected");
        ThisGameObject?.Invoke(player.gameObject);
        CharacterTreasureCount?.Invoke(1);
        /*Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.treasureCount++;
        }*/
    }

    public GameObject ThisGO()
    {
        return gameObject;
    }
}

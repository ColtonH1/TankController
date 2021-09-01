using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    Color[] childColors;
    Material material;

    private void WhenAwake(Player player, int i)
    {
        childColors[i] = player.transform.GetChild(i).GetComponent<Color>();
    }

    public override void PowerUp(Player player)
    { 
        /*
        if (player.GetComponent<Material>())
        {
            WhenAwake(player);
            player.GetComponent<Renderer>().color = Color.white;
        }
        */

        for(int i = 0; i < player.transform.childCount; i++)
        {
            if(player.transform.GetChild(i).childCount != 0)
            {
                if(player.transform.GetChild(i).GetChild(i).GetComponent<Material>())
                {
                    WhenAwake(player, i);
                    material = player.transform.GetChild(i).GetChild(i).GetComponent<Material>();
                    material.color = Color.white;

                }
            }

        }
    }

    public override void PowerDown(Player player)
    {
    }
}

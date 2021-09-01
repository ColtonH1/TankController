using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Material newMat;
    [SerializeField] Material old1;
    [SerializeField] Material old2;
    Renderer[] children;
    public static bool isActive;

    public override void PowerUp(Player player)
    {
        children = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (int j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
        isActive = true;
    }

    public override void PowerDown(Player player)
    {
        children = player.GetComponentsInChildren<Renderer>();
        int i = 0;
        foreach (Renderer rend in children)
        {
            if(i == 0 || i == 3)
            {
                rend.material = old1;
            }
            if(i == 1 || i ==2)
            {
                rend.material = old2;
            }
            i++;
        }
        isActive = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    protected override void Impact(CharacterStats stats, CharacterCombat combat)
    {
        if(stats != null)
        {
            Debug.Log("Has explosive bullet");
            stats.Kill();
        }

    }
}

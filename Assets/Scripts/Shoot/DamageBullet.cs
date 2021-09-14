using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : Bullet
{
    protected override void Impact(CharacterStats stats, CharacterCombat combat)
    {
        if (stats != null)
        {
            Debug.Log("Has damage bullet");
            combat.Attack(stats);
        }
    }
}

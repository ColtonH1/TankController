/*
 * This script is the bullet that deals basic damage
 * It simply calls the characer combat script to announce it has attacked and which IDamageable it attacked
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : BulletBase
{
    [Header("Damage Bullet")]
    [SerializeField] int amount;
    protected override void Impact(IDamageable damageable, CharacterCombat combat)
    {
        combat.Attack(damageable, amount);
    }
}

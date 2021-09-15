using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : BulletBase
{
    [Header("Damage Bullet")]
    [SerializeField] int amount;
    protected override void Impact(IDamageable damageable, CharacterCombat combat)
    {
        Debug.Log("Has damage bullet");
        combat.Attack(damageable, amount);
    }
}

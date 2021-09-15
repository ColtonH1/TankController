using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown;

    public float attackDelay = .6f;


    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(IDamageable damageable, int amount)
    {
        if(attackCooldown <= 0f)
        {
            Debug.Log(transform.name + " is attacking " + damageable.GetGameObject().name);
            damageable.TakeDamage(amount);
            attackCooldown = 3f / attackSpeed;
        }
    }
}

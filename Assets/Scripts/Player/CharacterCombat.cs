using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown;

    public float attackDelay = .6f;

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            Debug.Log(transform.name + " is attacking " + targetStats.name);
            targetStats.DecreaseHealth(1);
            attackCooldown = 3f / attackSpeed;
        }
    }
}

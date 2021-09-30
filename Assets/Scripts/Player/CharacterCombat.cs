/*
 * This script calls the take damage function in the character's health script using the IDamageable interface as the basis for which character got hurt
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown;

    public float attackDelay = .6f;

    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] AudioClip hitSound;
    [SerializeField] float volume = 1f;


    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void React(IDamageable damageable, int amount)
    {
        if (attackCooldown <= 0f)
        {
            if (hitParticles != null)
            {
                Instantiate(hitParticles, transform.position, hitParticles.transform.rotation);
            }
            if (hitSound != null)
            {
                AudioHelper.PlayClip2D(hitSound, volume);
            }
            Attack(damageable, amount);
            attackCooldown = 3f / attackSpeed;
        }
    }

    public void Attack(IDamageable damageable, int amount)
    {
        if(attackCooldown <= 0f)
        {
            damageable.TakeDamage(amount);
            attackCooldown = 3f / attackSpeed;
        }
    }
}

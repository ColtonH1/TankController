using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown;

    public float attackDelay = .6f;

    //CharacterStats myStats;

    private void Start()
    {
        //myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            Debug.Log("CharCombatAttack");
            //StartCoroutine(DoDamage(targetStats, attackDelay));
            targetStats.DecreaseHealth(1);
            attackCooldown = 1f / attackSpeed;
        }
    }

    /*
    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log("CharCombatAttack after one second");
        stats.DecreaseHealth(1);
    }*/
}

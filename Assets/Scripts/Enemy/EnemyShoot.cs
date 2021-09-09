using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShootProjectiles
{
    [Header("Enemy Shoot")]
    public float startWaitTime;
    private float waitTime;

    EnemyController enemyController;
    CharacterCombat combat;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        combat = GetComponent<CharacterCombat>();
    }

    private void Start()
    {
        waitTime = startWaitTime;
    }
    private void Update()
    {
        //Shoot();
    }

    public void Shoot()
    {
        //every so often, FireObject()
        if (waitTime <= 0)
        {
            FireObject();
            Debug.Log("Enemy Shot Player");
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public override void FireReaction()
    {
        //damage player
    }
}

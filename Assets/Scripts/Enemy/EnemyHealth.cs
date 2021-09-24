using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : HealthBase
{
    [Header("Enemy Health")]
    Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
    }

    public override void Kill()
    {
        EnemyController enemyController = gameObject.GetComponentInChildren<EnemyController>();
        if (enemyController != null)
            enemyController.enabled = false;
        SkinnedMeshRenderer skinnedMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
            skinnedMeshRenderer.enabled = false;
        Canvas canvas = gameObject.GetComponentInChildren<Canvas>();
        if (canvas != null)
            canvas.enabled = false;
        base.Kill();
    }
}

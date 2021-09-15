using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    [Header("Enemy Health")]
    Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void Kill()
    {
        EnemyController enemyController = gameObject.GetComponentInChildren<EnemyController>();
        if (enemyController != null)
            enemyController.enabled = false;
        SkinnedMeshRenderer skinnedMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
            skinnedMeshRenderer.enabled = false;
        base.Kill();
    }
}

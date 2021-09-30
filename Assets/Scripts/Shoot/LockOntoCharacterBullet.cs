using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOntoCharacterBullet : BulletBase
{
    [Header("Lock On Bullet")]
    [SerializeField] int amount;
    GameObject enemyManager;
    public float speed = 10f;
    Rigidbody rigBody;

    private void Start()
    {
        enemyManager = EnemyManager.instance.enemy;
        rigBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (enemyManager.activeInHierarchy)
            LockOnCharacter();
        else
            Destroy(gameObject, 5);
    }

    private void LockOnCharacter()
    {
        Vector3 direction = (enemyManager.transform.position - transform.position).normalized * speed;
        transform.LookAt(enemyManager.transform);
        rigBody.velocity = new Vector3(direction.x, 0, direction.z);
    }

    protected override void Impact(IDamageable damageable, CharacterCombat combat)
    {
        combat.Attack(damageable, amount);
    }
}

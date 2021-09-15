using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackBullet : BulletBase
{
    [SerializeField] private float knockbackStrength;

    protected override void Impact(IDamageable damageable, CharacterCombat combat)
    {
        GameObject gameObject = damageable.GetGameObject();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            Vector3 direction = gameObject.transform.position - transform.position;
            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }

    }

}

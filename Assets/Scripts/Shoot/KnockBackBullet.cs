using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackBullet : Bullet
{
    [SerializeField] private float knockbackStrength;

    protected override void Impact(CharacterStats stats, CharacterCombat combat)
    {
        if(stats != null)
        {
            Vector3 direction = stats.transform.position - transform.position;
            stats.GetComponent<Rigidbody>().AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }
    }

}

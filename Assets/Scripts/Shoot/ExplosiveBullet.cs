using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : BulletBase
{
    protected override void Impact(IDamageable damageable, CharacterCombat combat)
    {

        Debug.Log("Has explosive bullet");

        damageable.GetGameObject().GetComponent<HealthBase>().Kill();

    }
}

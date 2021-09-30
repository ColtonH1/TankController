/*
 * This script defines the bullet that can knock back a character
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackBullet : BulletBase
{
    [SerializeField] private float knockbackStrength;
    public CameraShake cameraShake;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    protected override void Impact(IDamageable damageable, CharacterCombat combat)
    {
        GameObject gameObject = damageable.GetGameObject();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            if(rb.gameObject.CompareTag("Player"))
            {
                StartCoroutine(cameraShake.Shake(.15f, .4f));
            }
            Vector3 direction = gameObject.transform.position - transform.position;
            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }

    }

}

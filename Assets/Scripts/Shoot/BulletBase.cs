using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] GameObject impactParticles;
    [SerializeField] AudioClip impactSound;
    [SerializeField] float volume = 1f;

    protected abstract void Impact(IDamageable damageable, CharacterCombat combat);

    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            CharacterCombat combat = gameObject.GetComponent<CharacterCombat>();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;

            if (impactParticles != null)
            {
                Instantiate(impactParticles, transform.position, impactParticles.transform.rotation);
            }
            if (impactSound != null)
            {
                AudioHelper.PlayClip2D(impactSound, volume);
            }
            Impact(damageable, combat);
        }
    }
}

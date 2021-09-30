/*
 * This script is the base for how bullets work
 * On a collision, the bullet will find the IDamagable script attached to the object is hit and determine that object as what was attacked
 * Impact() will be called for the bullet scripts to determine how to deal with the collided object
 */
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

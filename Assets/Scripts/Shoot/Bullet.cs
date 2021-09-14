using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] GameObject impactParticles;
    [SerializeField] AudioClip impactSound;
    [SerializeField] float volume = 1f;

    protected abstract void Impact(CharacterStats stats, CharacterCombat combat);

    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CharacterCombat combat = gameObject.GetComponent<CharacterCombat>();
        CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>();
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
        Impact(stats, combat);

        Destroy(gameObject, 5);
    }
}

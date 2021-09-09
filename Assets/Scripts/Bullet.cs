using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject impactParticles;
    [SerializeField] AudioClip impactSound;
    [SerializeField] float volume = 1f;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CharacterCombat combat = gameObject.GetComponent<CharacterCombat>();
        CharacterStats stats = collision.rigidbody.GetComponent<CharacterStats>();
        //CharacterStats stats = collision.GetComponent<CharacterStats>();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        if (stats != null)
        {
            Debug.Log("Attacking: " + stats);
            combat.Attack(stats);
        }
        if (impactParticles != null)
        {
            GameObject impact = Instantiate(impactParticles, transform.position, impactParticles.transform.rotation);
        }
        if (impactSound != null)
        {
            AudioHelper.PlayClip2D(impactSound, volume);
        }
        Destroy(gameObject, 5);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        CharacterCombat combat = gameObject.GetComponent<CharacterCombat>();
        CharacterStats stats = other.GetComponent<CharacterStats>();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        if (stats != null)
        {
            Debug.Log("Attacking: " + stats);
            combat.Attack(stats);
        }
        if (impactParticles != null)
        {
            GameObject impact = Instantiate(impactParticles, transform.position, impactParticles.transform.rotation);
        }
        if (impactSound != null)
        {
            AudioHelper.PlayClip2D(impactSound, volume);
        }
        Destroy(gameObject, 5);
    }*/
}

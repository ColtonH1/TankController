/*
 * This script is the base for shooting projectiles
 * It determines the first projectile's impact result (particles and sound)
 */
using UnityEngine;

public class ShootProjectilesBase : MonoBehaviour
{
    [Header("Shoot Projectiles")]

    [SerializeField] ParticleSystem shootParticles;
    [SerializeField] AudioClip shootSound;
    public float launchVelocity = 700f; //speed of projectile
    [SerializeField] float volume = 1f; 

    protected GameObject ball;

    public virtual void FireObject(GameObject projectile, GameObject launchOrigin)
    {
            ball = Instantiate(projectile, launchOrigin.transform.position, transform.rotation);
            if (shootParticles != null)
            {
                Instantiate(shootParticles, launchOrigin.transform.position, shootParticles.transform.rotation);
            }
            if (shootSound != null)
            {
                AudioHelper.PlayClip2D(shootSound, volume);
            }
    }
}

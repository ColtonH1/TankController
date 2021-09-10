using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    [Header("Shoot Projectiles")]

    public GameObject projectile;
    [SerializeField] GameObject launchOrigin;
    [SerializeField] ParticleSystem shootParticles;
    [SerializeField] AudioClip shootSound;
    public float launchVelocity = 700f;
    [SerializeField] float volume = 1f;

    protected GameObject ball;

    public virtual void FireObject()
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
            //ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, launchVelocity);
    }

    public virtual void FireReaction()
    {

    }


}

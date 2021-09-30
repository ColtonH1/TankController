/*
 * This script determines the initial enemy which only hurt the enemy when ran into
 * At the moment, this script is no relevant to the game
 * This script could still be used for object that might the enemy i.e. road spikes
 */
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if(player != null && !player.isInvuln)
        {
            PlayerImpact(player);
            ImpactFeedback();
        }
    }

    protected virtual void PlayerImpact(PlayerHealth player)
    {
        player.TakeDamage(_damageAmount);
    }

    private void ImpactFeedback()
    {
        //particles
        if(_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }

        //audio. TODO - consider Object Pooling for performance 
        if(_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

    }
}

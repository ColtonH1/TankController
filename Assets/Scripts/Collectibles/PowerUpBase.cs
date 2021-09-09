using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public abstract void PowerUp(Player2 player);
    public abstract void PowerDown(Player2 player);
    [SerializeField] float powerupDuration;

    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    private void OnTriggerEnter(Collider other)
    {
        Player2 player = other.gameObject.GetComponent<Player2>();
        if(player != null)
        {
            PowerUp(player);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            ImpactFeedback();
            StartCoroutine(EndPowerup(player, powerupDuration));
        }

    }

    private IEnumerator EndPowerup(Player2 player, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PowerDown(player);
        Destroy(this.gameObject);
    }

    private void ImpactFeedback()
    {
        //particles
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }

        //audio. TODO - consider Object Pooling for performance 
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public abstract void PowerUp(Player player);
    public abstract void PowerDown(Player player);
    [SerializeField] float powerupDuration;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            PowerUp(player);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(EndPowerup(player, powerupDuration));
        }

    }

    private IEnumerator EndPowerup(Player player, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PowerDown(player);
        Destroy(this.gameObject);
    }



}

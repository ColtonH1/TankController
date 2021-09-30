/*
 * This script is the base script for checking if one character is within range of an interactable object or other character
 */

using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    public float radius = 3f;
    Transform player;

    public virtual void Interact()
    {

    }

    private void Update()
    {
        float distance = Vector3.Distance(PlayerManager.instance.player.transform.position, transform.position);
        if(distance <= radius)
        {
            Interact();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

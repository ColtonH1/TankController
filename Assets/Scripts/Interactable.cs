using UnityEngine;

public class Interactable : MonoBehaviour
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

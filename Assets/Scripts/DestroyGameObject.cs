/*
 * The script simply destroys the gameobject when called
 * This script can also return the gameobject attached the script is attached to
 * This script is good use on non character objects that just need to be destroyed
 */
using UnityEngine;

public class DestroyGameObject : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        Destroy(gameObject);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}

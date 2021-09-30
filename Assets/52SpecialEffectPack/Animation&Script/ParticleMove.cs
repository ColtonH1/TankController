/*
 * This script determines how a particle system will move and what to do upon impact
 */

using UnityEngine;
using System.Collections;

public class ParticleMove : MonoBehaviour
{
    public float speed = 10f;
    GameObject player;
    Rigidbody rigBody;

    private void Start()
    {
        player = PlayerManager.instance.player;
        rigBody = GetComponent<Rigidbody>();
    }

    void Update () 
    {
        Vector3 direction = (player.transform.position - transform.position).normalized * speed;
        rigBody.velocity = new Vector3(direction.x, direction.y, direction.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject fireBall = GameObject.Find("FireBall(Clone)");
        if(fireBall != null)
        {
            GameObject.Find("FireBall(Clone)").SetActive(false);
        }

        GameObject swampBall = GameObject.Find("SwampBall(Clone)");
        if (swampBall != null)
        {
            GameObject.Find("SwampBall(Clone)").SetActive(false);
        }

        Destroy(gameObject);
    }
}

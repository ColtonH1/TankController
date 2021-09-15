using UnityEngine;
using System.Collections;

public class csParticleMove : MonoBehaviour
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

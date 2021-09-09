using UnityEngine;
using System.Collections;

public class csParticleMove : MonoBehaviour
{
    public float speed = 0.1f;
    GameObject player;

    private void Start()
    {
        player = PlayerManager.instance.player;
    }

    void Update () {
        //transform.Translate(Vector3.back * speed);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}
}

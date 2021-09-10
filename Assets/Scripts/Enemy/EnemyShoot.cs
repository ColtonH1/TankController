using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShootProjectiles
{
    [Header("Enemy Shoot")]

    //keep time between firing
    public float startWaitTime;
    private float waitTime;

    //for second projectile to shoot
    [SerializeField] GameObject launchOrigin2;
    public GameObject hardBodyAmmo;
    private GameObject ammo;

    GameObject player;
    public float speed = 700f;

    private void Start()
    {
        player = PlayerManager.instance.player;
        waitTime = 0;
    }
    private void Update()
    {
        //Shoot();
    }

    public void Shoot()
    {
        //every so often, FireObject()
        if (waitTime <= 0)
        {
            FireObject();
            Debug.Log("Enemy Shot Player");
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public override void FireObject()
    {
        base.FireObject();
        ammo = Instantiate(hardBodyAmmo, launchOrigin2.transform.position, transform.rotation);
        ammo.transform.LookAt(player.transform);
        /*Vector3 direction = (player.transform.position - ammo.transform.position).normalized * speed;
        ammo.GetComponent<Rigidbody>().velocity = new Vector3(direction.x, direction.y, direction.z);*/

        ammo.GetComponent<MeshRenderer>().enabled = false;
        ammo.AddComponent<csParticleMove>();
    }

    public override void FireReaction()
    {
        //damage player
    }
}

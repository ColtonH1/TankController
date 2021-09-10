using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootProjectiles
{
    [Header("Player Shoot")]
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireObject();
        }
    }

    public override void FireReaction()
    {
        //damage enemy
    }

    public override void FireObject()
    {
        base.FireObject();
        if(ball != null)
            ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, launchVelocity);
    }
}

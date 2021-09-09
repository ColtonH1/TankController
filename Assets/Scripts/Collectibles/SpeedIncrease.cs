﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = .5f;

    protected override void Collect(Player2 player)
    {
        //pull motor controller from the player
        TankController controller = player.GetComponent<TankController>();
        if(controller != null)
        {
            controller.MaxSpeed += _speedAmount;
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        //calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
    }
}
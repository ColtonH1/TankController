using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : CharacterStats
{
    TankController _tankController;
    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Update()
    {
        isInvuln = Invincibility.isActive;
    }

    public override void Kill()
    {
        base.Kill();
        PlayerManager.instance.KillPlayer();
    }
}

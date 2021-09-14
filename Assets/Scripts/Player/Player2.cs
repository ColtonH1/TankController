﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : CharacterStats
{
    [Header("Player2")]
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
        StartCoroutine(ResetLevel());
        base.Kill();
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1);
        PlayerManager.instance.KillPlayer();
    }
}

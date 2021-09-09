﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void Kill()
    {
        base.Kill();
    }
}
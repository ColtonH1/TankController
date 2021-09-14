using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyInteract : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;
    CharacterCombat combat;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
        combat = GetComponent<CharacterCombat>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterStats targetStats = playerManager.player.GetComponent<CharacterStats>();
        if (targetStats != null)
        {
            combat.Attack(targetStats);
        }

    }
}

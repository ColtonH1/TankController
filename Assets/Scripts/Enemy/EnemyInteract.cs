using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class EnemyInteract : Interactable
{
    PlayerManager playerManager;
    HealthBase myStats;
    CharacterCombat combat;
    [SerializeField] int amount;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<HealthBase>();
        combat = GetComponent<CharacterCombat>();
    }
    public override void Interact()
    {
        base.Interact();
        HealthBase targetStats = playerManager.player.GetComponent<HealthBase>();
        if (targetStats != null)
        {
            combat.Attack(targetStats, amount);
        }

    }
}

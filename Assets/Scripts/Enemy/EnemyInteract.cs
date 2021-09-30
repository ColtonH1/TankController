/*
 * This script decides if the enemy is close enough to the player to intereact with
 */
using UnityEngine;

[RequireComponent(typeof(HealthBase))]
public class EnemyInteract : InteractableBase
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
            combat.React(targetStats, amount);
            //combat.Attack(targetStats, amount);
        }

    }
}

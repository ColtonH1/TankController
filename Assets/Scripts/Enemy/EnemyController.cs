using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    EnemyShoot enemyShoot;

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX, minZ, maxX, maxZ;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        enemyShoot = GetComponent<EnemyShoot>();
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float distance = Vector3.Distance(target.position, transform.position); //distance between player and enemy

        //if player is within look radius, then follow player, if not, then patrol randomly
        if (distance <= lookRadius)
        {
            FollowPlayer(distance);
        }
        //else set destination to random patrol target and wait the determined amount of seconds before moving to next target
        else
        {
            Patrol();
        }
    }

    private void FollowPlayer(float distance)
    {
        agent.SetDestination(target.position);

        if (distance <= agent.stoppingDistance)
        {
            Player2 targetStats = target.GetComponent<Player2>();
            if (targetStats != null)
            {
                enemyShoot.Shoot();
                //combat.Attack(targetStats);
            }

            FaceTarget(target);
        }
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }

    private void Patrol()
    {
        agent.SetDestination(moveSpot.position);
        FaceTarget(moveSpot);
        if (Vector3.Distance(transform.position, moveSpot.position) <= agent.stoppingDistance)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void FaceTarget(Transform facing)
    {
        Vector3 direction = (facing.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

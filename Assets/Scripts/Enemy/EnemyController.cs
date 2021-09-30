/*
 * This script controls the enemy movement
 * This script controls when enemy lunges at player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target; //player
    NavMeshAgent agent; //enemy movement agent
    EnemyShoot enemyShoot; //script for shooting from the enemy

    public float speed; //how fast the enemy moves
    private float waitTime; //how long to wait in between patrols
    public float waitTimeForChargeAttack; //how long to wait until charge attack after warning appears
    public float waitThisLong; //how long to wait to reinitialize the contraints
    public float startWaitTime; //the start wait time to wait in between patrols

    public Transform moveSpot; //where to patrol to next
    public float minX, minZ, maxX, maxZ; //where the patrol spot will pop up next

    [SerializeField] int jumpHeight; //how high to jump...if jumping works
    private bool isGrounded; //checks if enemy is jumping or not
    private Rigidbody rb; //enemy's rigidbody
    public float distToGround = 1f; //maxium distance to not be considered jumping
    public Image exclamationMark1;
    public Image exclamationMark2;


    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyShoot = GetComponent<EnemyShoot>();
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        rb = GetComponent<Rigidbody>();
        exclamationMark1.enabled = false;
        exclamationMark2.enabled = false;
    }

    private void Update()
    {
        
        int random = Random.Range(0, 1000);
        
        if (isGrounded && (random == 1))
        {
            StartCoroutine(ChargePlayer(waitTimeForChargeAttack));
        }
        else
            Move();
    }

    private void FixedUpdate()
    {
        GroundCheck();
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

        PlayerHealth targetStats = target.GetComponent<PlayerHealth>();
        if (targetStats != null)
        {
            enemyShoot.Shoot();
        }

        FaceTarget(target);
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

    //jump attack
    private void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            Debug.Log("Grounded");
            isGrounded = true;
        }
        else
        {
            Debug.Log("Not Grounded");
            isGrounded = false;
        }
    }

    IEnumerator ChargePlayer(float waitingTime)
    {
        Debug.Log("Showing !!!");
        exclamationMark1.enabled = true;
        exclamationMark2.enabled = true;
        yield return new WaitForSeconds(waitingTime);
        Vector3 distance = target.transform.position - transform.position;
        if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints.None;
            FaceTarget(target.transform);
            rb.AddForce(new Vector3(distance.x, 0, distance.z), ForceMode.Impulse);
            FaceTarget(target.transform);
            StartCoroutine(FreezeContraints(waitThisLong));
        }
        exclamationMark1.enabled = false;
        exclamationMark2.enabled = false;
    }

    IEnumerator FreezeContraints(float waitThisLong)
    {
        yield return new WaitForSeconds(waitThisLong);

        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}

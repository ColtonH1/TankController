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
    public float waitThisLong;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX, minZ, maxX, maxZ;

    [SerializeField] int jumpHeight;
    private bool isGrounded;
    private Rigidbody rb;
    public float distToGround = 1f;


    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        enemyShoot = GetComponent<EnemyShoot>();
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        int random = Random.Range(0, 1000);
        
        if (isGrounded && (random == 1))
        {
            JumpAttacking();
            Debug.Log(random);
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

        //if (distance <= agent.stoppingDistance)
        //{
            PlayerHealth targetStats = target.GetComponent<PlayerHealth>();
            if (targetStats != null)
            {
                enemyShoot.Shoot();
                //combat.Attack(targetStats);
            }

            FaceTarget(target);
        //}
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

    private void JumpAttacking()
    {
        Vector3 distance = target.transform.position - transform.position;
        Debug.Log(isGrounded);
        if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints.None;
            FaceTarget(target.transform);
            rb.AddForce(new Vector3(distance.x, jumpHeight, distance.z), ForceMode.Impulse);
            StartCoroutine(FreezeContraints(waitThisLong));
        }
    }

    IEnumerator FreezeContraints(float waitThisLong)
    {
        yield return new WaitForSeconds(waitThisLong);

        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}

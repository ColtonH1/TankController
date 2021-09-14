using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    [SerializeField] GameObject player; 
    [SerializeField] Transform groundCheck; 
    [SerializeField] int jumpHeight;
    [SerializeField] Vector2 boxSize;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody rb;

    //check if grounded
    public float distToGround = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.J))
        {
            JumpAttacking();
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

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
        Vector3 distance = player.transform.position - transform.position;
        Debug.Log(isGrounded);
        if(isGrounded)
        {
            FaceTarget(player.transform);
            rb.AddForce(new Vector3(distance.x, jumpHeight, distance.z), ForceMode.Impulse);
        }
    }

    void FaceTarget(Transform facing)
    {
        Vector3 direction = (facing.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
    }
}

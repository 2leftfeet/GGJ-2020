using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class SimpleCharacterController : BaseCharacterController
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float gravity = 10.0f; //Let's create gravity manually so it's easier to tinker with
    [SerializeField] private float maxVelocityChange = 10.0f;
    [SerializeField] private float jumpHeight = 2.0f;

    [SerializeField] private Vector3 groundCheckRayOffset;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] float groundCheckRayDistance;

    private Rigidbody rb;
    private bool grounded;

    private bool doubleJumpAvailable = false;

    [SerializeField] bool hasDoubleJump = false;

    private bool shouldJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    
    void Update()
    {
        if ((grounded || doubleJumpAvailable) && Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = GroundCheck();
        if(grounded && hasDoubleJump)
        {
            doubleJumpAvailable = true;
        }
        //Calculate how out target velocity based on current input
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(targetVelocity.magnitude > 1.0f)
            targetVelocity = targetVelocity.normalized;
        targetVelocity *= speed;

        //Apply a force that tries to reach the target velocity, but does not exceed maxVelocityChange
        Vector3 velocityChange = targetVelocity - rb.velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // Jump
        if (shouldJump)
        {
            shouldJump = false;
            rb.velocity = new Vector3(rb.velocity.x, CalculateJumpVerticalSpeed(), rb.velocity.z);
            if(!grounded && doubleJumpAvailable)
            {
                doubleJumpAvailable = false;
            }
        }

        //Apply gravity
        rb.AddForce(Vector3.down * gravity);

        if(rb.velocity.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(targetVelocity);
        }
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    bool GroundCheck()
    {
        if (Physics.Raycast(transform.position + groundCheckRayOffset, Vector3.down, groundCheckRayDistance, groundCheckLayerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position + groundCheckRayOffset, Vector3.down * groundCheckRayDistance);

        //Gizmos.DrawSphere(transform.position, 3.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCharacterController : BaseCharacterController
{
    public GameObject model;

    public float moveSpeed = 15;
    public float jumpHeight = 10;
    private Vector3 moveDir;
    private Rigidbody rb;
    public FauxBody fb;


    public float maxVelocityChange;

    private bool doubleJumpAvailable;
    private bool shouldJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        fb = gameObject.GetComponent<FauxBody>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (grounded && hasDoubleJump)
        {
            doubleJumpAvailable = true;
        }

        if ((grounded || doubleJumpAvailable) && Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            maxVelocityChange = 1f;
        }
        else
        {
            maxVelocityChange = 0.1f;
        }

        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (targetVelocity.magnitude > 1.0f)
            targetVelocity = targetVelocity.normalized;

        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= moveSpeed;

        //Apply a force that tries to reach the target velocity, but does not exceed maxVelocityChange
        Vector3 velocityChange = targetVelocity - rb.velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // Jump
        if (shouldJump)
        {
            shouldJump = false;
            rb.velocity = (fb.transform.position - fb.attractor.transform.position).normalized * jumpHeight;
            if (!grounded && doubleJumpAvailable)
            {
                doubleJumpAvailable = false;
            }
        }

        if(rb.velocity.magnitude >= 0.5f)
        {
            model.transform.rotation = Quaternion.LookRotation(targetVelocity, fb.transform.position - fb.attractor.transform.position);
        }

        //grounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8 // World layer //check the int value in layer manager(User Defined starts at 8) 
             && !grounded)
        {
            grounded = true;
            if (hasDoubleJump)
            {
                doubleJumpAvailable = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8
            && grounded)
        {
            grounded = false;
        }
    }
}

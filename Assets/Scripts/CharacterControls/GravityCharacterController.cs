using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCharacterController : BaseCharacterController
{
    public float moveSpeed = 15;
    public float jumpHeight = 10;
    private Vector3 moveDir;
    private Rigidbody rb;
    public bool grounded = true;
    public FauxBody fb;

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
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

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
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);

        // Jump
        if (shouldJump)
        {
            shouldJump = false;
            rb.velocity = (fb.transform.position - fb.attractor.transform.position).normalized * 10;
            if (!grounded && doubleJumpAvailable)
            {
                doubleJumpAvailable = false;
            }
        }

        //grounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8 // World layer //check the int value in layer manager(User Defined starts at 8) 
             && !grounded)
        {
            grounded = true;
            hasDoubleJump = true;
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

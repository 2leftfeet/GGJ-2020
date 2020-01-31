using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    public float jumpHeight = 10;
    private Vector3 moveDir;
    private Rigidbody rb;
    public bool grounded = true;
    public FauxBody fb;
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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);

        // Jump
        if (grounded)
        {
            if (Input.GetButton("Jump"))
            {
                rb.velocity = (fb.transform.position - fb.attractor.transform.position).normalized * 10;
            }
        }

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }
}

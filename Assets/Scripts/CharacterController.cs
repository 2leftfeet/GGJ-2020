using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
 
public class CharacterController : MonoBehaviour {
 
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;
    private Vector3 moveDirection = Vector3.zero;
    public float turnspeed = 180f;
    Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Awake () {
	    GetComponent<Rigidbody>().freezeRotation = true;
	    GetComponent<Rigidbody>().useGravity = false;
	}
 
	void FixedUpdate() {
	    // Calculate how fast we should be moving
	    Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	    //targetVelocity = transform.TransformDirection(targetVelocity);
	    targetVelocity *= speed;
 
	    // Apply a force that attempts to reach our target velocity
	    Vector3 velocity = rb.velocity;
	    Vector3 velocityChange = (targetVelocity - velocity);
	    velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	    velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	    velocityChange.y = 0;
	    rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // Jump
        if (grounded) {
            if (canJump && Input.GetButton("Jump"))
            {
                rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }

        if (targetVelocity.magnitude > 0.1f && grounded)
            transform.rotation = Quaternion.LookRotation(velocity);

        // We apply gravity manually for more tuning control
        //rb.AddForce(new Vector3 (0, -gravity * rb.mass, 0));

	    grounded = false;
	}
 
	void OnCollisionStay () {
	    grounded = true;    
	}
 
	float CalculateJumpVerticalSpeed () {
	    // From the jump height and gravity we deduce the upwards speed 
	    // for the character to reach at the apex.
	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{

    public Transform Shadow;
    float startingDistance;
    float currentDistance;
    public GameObject Player;
    Rigidbody rb;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), Player.GetComponent<CapsuleCollider>());
        rb = GetComponent<Rigidbody>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.collider)
            {
                startingDistance = Vector3.Distance(transform.position, hit.point);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.collider)
            {
                Shadow.transform.position = hit.point;
                currentDistance = Vector3.Distance(transform.position, hit.point);
            }
            
        }

        float shadowSize = 1.5f - currentDistance / startingDistance;
        Vector3 newShadow = new Vector3(shadowSize, Shadow.transform.localScale.y, shadowSize);
        Shadow.localScale = newShadow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8) // World layer //check the int value in layer manager(User Defined starts at 8))
        {
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

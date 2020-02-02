using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    public LayerMask hitmask;
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
        Shadow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, hitmask))
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
            Shadow.gameObject.SetActive(true);
        }
    }
}

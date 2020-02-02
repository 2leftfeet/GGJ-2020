using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;
    public bool lockedRotation = true;
    private Transform myTransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        attractor = FindObjectOfType<FauxGravityAttractor>();
        rb = gameObject.GetComponent<Rigidbody>();
        if(lockedRotation) rb.constraints = RigidbodyConstraints.FreezeRotation;
        if (attractor)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (attractor)
        {
            attractor.Attract(myTransform, lockedRotation);

        }
    }
}

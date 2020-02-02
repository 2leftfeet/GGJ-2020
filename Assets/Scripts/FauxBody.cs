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
        rb = gameObject.GetComponent<Rigidbody>();
        if(lockedRotation) rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(myTransform, lockedRotation);
    }
}

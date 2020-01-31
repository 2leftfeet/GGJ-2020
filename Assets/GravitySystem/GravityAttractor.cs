using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rb;

    private GravityObject[] gravityObjects;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityObjects = FindObjectsOfType<GravityObject>();
    }

    void Update()
    {
        foreach (GravityObject gravityObject in gravityObjects)
        {
            Attract(gravityObject);
        }
    }

    void Attract(GravityObject toAttract)
    {
        Rigidbody rbToAttract = toAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / (distance * distance);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

    
}

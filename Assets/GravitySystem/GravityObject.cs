using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 gravityDirection;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
}

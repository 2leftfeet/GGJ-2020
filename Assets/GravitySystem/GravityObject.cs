using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    public Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }
}

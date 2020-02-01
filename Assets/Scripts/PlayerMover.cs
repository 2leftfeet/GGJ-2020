using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    GravityObject gravityObject;

    // Start is called before the first frame update
    void Start()
    {
        gravityObject = GetComponent<GravityObject>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.up, -gravityObject.gravityDirection);
    }
}

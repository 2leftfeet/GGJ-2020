using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundWorldPoint : MonoBehaviour
{
    public Vector3 point;
    public Vector3 axis;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, axis, Time.deltaTime * speed);
    }
}

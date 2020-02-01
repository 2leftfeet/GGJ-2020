using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lr.SetPosition(0, startPoint.position);
        //lr.SetPosition(1, endPoint.position);

        RaycastHit hit;
        if (Physics.Raycast(startPoint.position, endPoint.position, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else lr.SetPosition(1, endPoint.position);
    }
}

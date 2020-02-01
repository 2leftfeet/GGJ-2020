using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{

    public Transform Shadow;
    float startingDistance;
    float currentDistance;
    LayerMask layerMask = ~(1 << 8);
    // Start is called before the first frame update
    void Start()
    {
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
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1000f, layerMask))
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroCube : MonoBehaviour
{
    Material material;

    public bool isDissolving;

    private float t = 0;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDissolving)
        {
            material.SetFloat("_Treshold", t);
            t += Time.deltaTime;

            if(t >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}

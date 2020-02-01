using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMesh : MonoBehaviour
{
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    public void Activate()
    {
        mat.EnableKeyword("_EMISSION");
    }

    public void Deactivate()
    {
        mat.DisableKeyword("_EMISSION");
    }
}

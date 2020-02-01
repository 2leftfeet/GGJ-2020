using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSpinner : MonoBehaviour
{
    public Material skybox;
    public float rotationSpeed;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        skybox.SetFloat("_Rotation", t);
        t += rotationSpeed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDinamiskumas : MonoBehaviour
{
    [SerializeField]
    private float maxHeight = 5f;
    [SerializeField]
    private float minHeight = 5f;
    [SerializeField]
    private float maxTime = 6f;

    private float t = 0f;

    private void Update()
    {
        float timeFraction = t / maxTime;
        t += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(t, maxHeight - minHeight) + minHeight, transform.position.z);
    }
}

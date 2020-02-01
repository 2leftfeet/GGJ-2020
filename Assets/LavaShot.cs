using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaShot : MonoBehaviour
{

    private IEnumerator coroutine;
    Rigidbody rb;
    public float upForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coroutine = WaitAndShoot(5.0f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndShoot(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            ShootUp();
        }
    }

    void ShootUp()
    {
        rb.AddForce( new Vector3(0, 1, 0) * upForce);
    }
}

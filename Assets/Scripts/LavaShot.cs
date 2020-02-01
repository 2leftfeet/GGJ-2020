using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaShot : MonoBehaviour
{

    private IEnumerator coroutine;
    Rigidbody rb;
    public float rndForceMin = 10f;
    public float rndForceMax = 20f;
    public float rndMin = 5f;
    public float rndMax = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coroutine = WaitAndShoot();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndShoot()
    {
        while (true)
        {
            float waitTime = Random.Range(rndMin, rndMax);
            yield return new WaitForSeconds(waitTime);
            ShootUp();
        }
    }

    void ShootUp()
    {
        float upForce = Random.Range(rndForceMin, rndForceMax);
        rb.velocity = new Vector3(0, 1, 0) * upForce;
    }
}

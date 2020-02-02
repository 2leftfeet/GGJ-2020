using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NootNoot : MonoBehaviour
{
    private IEnumerator coroutine;
    Rigidbody rb;
    public Transform Target;
    public GameObject otherNoot;
    Vector3 direction;
    //public float speed = 1f;
    Vector3 initialPosition;
    public bool canSlide = false;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), otherNoot.GetComponent<BoxCollider>());
        initialPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        var heading = Target.position - transform.position;
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction.

        coroutine = WaitAndShoot();
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndShoot()
    {
        while (true)
        {
            float waitTime = Random.Range(1f, 5f);
            yield return new WaitForSeconds(waitTime);
            canSlide = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Random.Range(3f, 5f);
        if(canSlide) rb.AddForce(direction * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Target.gameObject)
        {
            canSlide = false;
            rb.velocity = Vector3.zero;
            transform.position = initialPosition;
        }
    }
}

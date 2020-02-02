using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSlide : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float destroyAfter = 5f;

    private Rigidbody rb;

    Vector3 direction;

    private bool canShoot;

    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        var heading = target.position - transform.position;
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction.

        StartCoroutine(WaitAndShoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot) rb.AddForce(direction * speed * Time.deltaTime) ;
    }

    private IEnumerator WaitAndShoot()
    {
        while (true)
        {
            float waitTime = Random.Range(1f, 5f);
            
            yield return new WaitForSeconds(destroyAfter);
            Destroy(this.gameObject);

        }
    }
}

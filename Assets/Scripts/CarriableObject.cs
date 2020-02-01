using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriableObject : MonoBehaviour
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Pickup()
    {
        rigidbody.isKinematic = true;
    }

    public virtual void Drop()
    {
        rigidbody.isKinematic = false;
    }

    public virtual void ActivateEffect()
    {

    }

    public virtual void OnEquip()
    {

    }

    public virtual void OnUnequip()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

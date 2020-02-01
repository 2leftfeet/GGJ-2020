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

    public virtual void ActivateEffect(CharacterHands characterHands)
    {

    }

    public virtual void OnEquip(CharacterHands characterHands)
    {
        rigidbody.isKinematic = true;
    }

    public virtual void OnUnequip(CharacterHands characterHands)
    {
        rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

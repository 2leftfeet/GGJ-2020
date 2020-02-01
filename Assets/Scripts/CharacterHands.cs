﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHands : MonoBehaviour
{
    public Transform carryingPointOffset;
    public Transform sphereCastOffset;
    public CarriableObject carriableInHands;

    public float lerpSpeed = 5f;
    private bool mustLerp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // -- INPUT --
        if (carriableInHands)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                carriableInHands.ActivateEffect(this);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Unequip();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider[] hits = Physics.OverlapSphere(sphereCastOffset.position, 0.5f);
                for(int i = 0; i < hits.Length; i++)
                {
                    CarriableObject carriableObject = hits[i].GetComponent<CarriableObject>();
                    if(carriableObject)
                    {
                        Equip(carriableObject);
                        break;
                    }
                }
            }
        }

        // -- OTHER --
        if (mustLerp)
        {
            // A bit expensive lerp
            carriableInHands.transform.localPosition = Vector3.Slerp(
                carriableInHands.transform.localPosition, Vector3.zero, Time.deltaTime * lerpSpeed);

            if (carriableInHands.transform.localPosition == Vector3.zero)
                mustLerp = false;
        }
    }

    void Equip(CarriableObject carriableObject)
    {
        carriableInHands = carriableObject;

        carriableInHands.OnEquip(this);
        carriableInHands.transform.SetParent(carryingPointOffset);

        Physics.IgnoreCollision(GetComponent<Collider>(), carriableInHands.GetComponent<Collider>());

        mustLerp = true;
    }

    void Unequip()
    {
        carriableInHands.OnUnequip(this);
        carriableInHands.transform.SetParent(null);

        Physics.IgnoreCollision(GetComponent<Collider>(), carriableInHands.GetComponent<Collider>(), false);

        carriableInHands = null;
        mustLerp = false;
    }
}

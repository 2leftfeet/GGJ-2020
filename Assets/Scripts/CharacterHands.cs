using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHands : MonoBehaviour
{
    public Transform carryingPointOffset;
    public Transform sphereCastOffset;
    public CarriableObject carriableInHands;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carriableInHands)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                carriableInHands.ActivateEffect();
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
    }

    void Equip(CarriableObject carriableObject)
    {
        carriableInHands = carriableObject;
        carriableInHands.OnEquip();
    }

    void Unequip()
    {
        carriableInHands = null;
        carriableInHands.OnUnequip();
    }
}

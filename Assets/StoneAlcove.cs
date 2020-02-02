using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAlcove : MonoBehaviour
{
    public StoneBowl[] bowls;
    
    bool active = false;

    [SerializeField] float riseHeight;

    Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position + transform.forward * riseHeight;
    }

    void Update()
    {
        if(!active)
        {
            bool allFilled = true;
            foreach(StoneBowl bowl in bowls)
            {
                if (!bowl.filled)
                {
                    allFilled = false;
                }
            }
            if (allFilled)
            {
                active = true;
            }

        }
        else
        {
            transform.position += 0.01f * (targetPos - transform.position);
        }

        
    }
}

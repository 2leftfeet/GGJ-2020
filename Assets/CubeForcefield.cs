using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeForcefield : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        var hands = collider.GetComponent<CharacterHands>();
        if (hands)
        {
            hands.Unequip();
        }

        var cube = collider.GetComponent<ElectroCube>();
        if (cube)
        {
            cube.isDissolving = true;
            cube.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

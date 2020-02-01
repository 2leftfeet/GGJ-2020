using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActivator : MonoBehaviour
{
    [SerializeField] PuzzleMechanism connectedMechanism;
    [SerializeField] LineMesh lineMesh;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PuzzleCube"))
        {
            connectedMechanism.Activate();
            lineMesh.Activate();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("PuzzleCube"))
        {
            connectedMechanism.Deactivate();
            lineMesh.Deactivate();
        }
    }
}

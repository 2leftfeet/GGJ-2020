using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int transitionToSceneID;

    public Vector3 exitPointOffset;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.position =  transform.position + exitPointOffset;
            SceneManager.LoadScene(transitionToSceneID);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position + exitPointOffset, 0.3f);
    }
}

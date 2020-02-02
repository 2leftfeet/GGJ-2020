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
            // Check if main world char instance has the object
            var hands = col.GetComponent<CharacterHands>();
            if (hands.carriableInHands && hands.GetComponent<SimpleCharacterController>())
            {
                hands.carriableInHands.GetComponent<PersistentObject>().sceneId = transitionToSceneID;
                GravityCharacterController.instance.GetComponent<CharacterHands>().Equip(hands.carriableInHands, true);
            }

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

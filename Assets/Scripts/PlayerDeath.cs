using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            StartCoroutine(LoadScene());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            StartCoroutine(LoadScene());
        }
    }

    public IEnumerator LoadScene()
    {
        TransitionController.instance.StartTransition();
        var hands = GetComponent<CharacterHands>();
        if (hands)
        {
            hands.Unequip();
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

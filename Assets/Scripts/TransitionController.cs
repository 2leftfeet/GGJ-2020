using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public static TransitionController instance;

    [SerializeField]
    private Animator transitionAnim;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartTransition()
    {
        StartCoroutine(LoadScene());
    }

    public IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        transitionAnim.SetTrigger("loaded");
    }
}

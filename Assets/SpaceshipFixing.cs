using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipFixing : MonoBehaviour
{
    [SerializeField] AudioClip fixSound;

    [SerializeField] GameObject brokenLeg;
    [SerializeField] GameObject fixedLeg;

    [SerializeField] GameObject brokenBooster;
    [SerializeField] GameObject fixedBooster;

    [SerializeField] GameObject brokenCube;
    [SerializeField] GameObject fixedCube;

    [SerializeField] GameObject brokenCanister;

    [SerializeField] int endingSceneIndex;

    int fixCount = 0;

    public void fixLeg()
    {
        brokenLeg.SetActive(false);
        fixedLeg.SetActive(true);
        UIEvents._instance.FoundShipLeg();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
        fixCount++;
    }

    public void fixBooster()
    {
        brokenBooster.SetActive(false);
        fixedBooster.SetActive(true);
        UIEvents._instance.FoundRocketBoost();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
        fixCount++;
    }

    public void fixPowerCube()
    {
        brokenCube.SetActive(false);
        fixedCube.SetActive(true);
        UIEvents._instance.FoundPinkCube();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
        fixCount++;
    }

    public void fixFuel()
    {
        brokenCanister.SetActive(false);
        UIEvents._instance.FoundFuelCanister();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
        fixCount++;
    }

    void Update()
    {
        if (fixCount == 4)
        {
            StartCoroutine(LoadScene());
        }
    }

    public IEnumerator LoadScene()
    {
        TransitionController.instance.StartTransition();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(endingSceneIndex);
    }
}

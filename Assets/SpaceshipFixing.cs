using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void fixLeg()
    {
        brokenLeg.SetActive(false);
        fixedLeg.SetActive(true);
        UIEvents._instance.FoundShipLeg();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
    }

    public void fixBooster()
    {
        brokenBooster.SetActive(false);
        fixedBooster.SetActive(true);
        UIEvents._instance.FoundRocketBoost();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
    }

    public void fixPowerCube()
    {
        brokenCube.SetActive(false);
        fixedCube.SetActive(true);
        UIEvents._instance.FoundPinkCube();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
    }

    public void fixFuel()
    {
        brokenCanister.SetActive(false);
        UIEvents._instance.FoundFuelCanister();
        AudioSource.PlayClipAtPoint(fixSound, transform.position);
    }
 }

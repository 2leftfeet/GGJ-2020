using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFixing : MonoBehaviour
{
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
    }

    public void fixBooster()
    {
        brokenBooster.SetActive(false);
        fixedBooster.SetActive(true);
    }

    public void fixPowerCube()
    {
        brokenCube.SetActive(false);
        fixedCube.SetActive(true);
    }

    public void fixFuel()
    {
        brokenCanister.SetActive(false);
    }
 }

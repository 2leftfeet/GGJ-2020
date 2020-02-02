using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEvents : MonoBehaviour
{

    public static UIEvents _instance = null;

    [SerializeField]
    private TextMeshProUGUI shipLeg;

    [SerializeField]
    private TextMeshProUGUI fuelCanister;

    [SerializeField]
    private TextMeshProUGUI energyCube;

    [SerializeField]
    private TextMeshProUGUI rocketBooster;

    public void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            Debug.Log(_instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void FoundShipLeg()
    {
        shipLeg.color = new Color32(0, 0, 0, 255);
    }

    public void FoundFuelCanister()
    {
        fuelCanister.color = new Color32(0, 0, 0, 255);
    }

    public void FoundPinkCube()
    {
        energyCube.color = new Color32(0, 0, 0, 255);
    }

    public void FoundRocketBoost()
    {
        rocketBooster.color = new Color32(0, 0, 0, 255);
    }
}

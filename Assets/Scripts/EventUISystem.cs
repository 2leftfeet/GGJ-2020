using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUISystem : MonoBehaviour
{
    [SerializeField]
    private Image fillBarImage;

    [SerializeField]
    private float fillAmoutPerUpdate = 1f;

    private void Update()
    {
        FillAmout();
    }

    private void FillAmout()
    {
        if (Input.GetKey(KeyCode.E))
        {
            fillBarImage.fillAmount += fillAmoutPerUpdate * Time.deltaTime;
        }
        
        if (fillBarImage.fillAmount == 1)  // Event callback that progress reached 100 percent
        {
            Debug.Log("Callback - Full Fill Progress");
            fillBarImage.fillAmount = 0;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            fillBarImage.fillAmount = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySystem : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float intensityAmount = 1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityAmount);

            Debug.Log("Battery has been picked");
            Destroy(gameObject);
        }
    }
}

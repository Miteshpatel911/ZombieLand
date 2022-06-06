using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float ZoomedOutFOV = 60f;
    [SerializeField] float ZoomedInFOV = 20f;
    [SerializeField] float ZoomedOutSensitivity = 2f;
    [SerializeField] float ZoomedInSensitivity = 0.5f;

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();

            }
            else
            {
                ZoomOut();

            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = ZoomedInFOV;
        fpsController.mouseLook.XSensitivity = ZoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = ZoomedInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = ZoomedOutFOV;
        fpsController.mouseLook.XSensitivity = ZoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = ZoomedOutSensitivity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomOutFOV = 40f;
    [SerializeField] float zoomInFOV = 20f;

    bool zoomInToggle = false;
    
    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomInToggle = false;
        fpsCamera.fieldOfView = zoomOutFOV;
    }

    private void ZoomIn()
    {
        zoomInToggle = true;
        fpsCamera.fieldOfView = zoomInFOV;
    }
}

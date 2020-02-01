using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float zoomSpeed = 3f;
    public float fovMin = 50;
    public float fovMax = 100;

    private Camera myCamera;

    // Use this for initialization
    void Start() {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            myCamera.fieldOfView += zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            myCamera.fieldOfView -= zoomSpeed;
        }
        myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, fovMin, fovMax);
    }
}

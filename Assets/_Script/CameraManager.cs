using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float zoomSpeed = 3f;
    public float fovMin = 50;
    public float fovMax = 100;


    private float rot;
    private Camera myCamera;
    private Vector3 storePos; //stores the rotation of the attached gameObject
    Quaternion farAway;

    // Use this for initialization
    void Start() {
        myCamera = GetComponent<Camera>();
        farAway = Quaternion.Euler(-36f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        storePos = gameObject.transform.eulerAngles;  //keeps storePos up to date 
    }

    // Update is called once per frame
    void Update() {
        rot = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime * -250f;

        if (rot != 0) {
            storePos = new Vector3(Mathf.Clamp(storePos.x + rot, -50f,-36f), storePos.y, storePos.z);
            transform.localEulerAngles = storePos;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            myCamera.fieldOfView += zoomSpeed;
            var close = Quaternion.Euler(-50f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            myCamera.fieldOfView -= zoomSpeed;
            var farAway = Quaternion.Euler(-36f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, fovMin, fovMax);
    }
}

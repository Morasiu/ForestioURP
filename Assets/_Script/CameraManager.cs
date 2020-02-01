using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour{
    [SerializeField]
    private float RotationSpped = -250f;
    [SerializeField]
    private float MinXRotation = -50f;
    [SerializeField]
    private float MaxXRotation = -36f;

    public float zoomSpeed = 3f;
    public float fovMin = 70;
    public float fovMax = 100;


    private float rot;
    private Camera myCamera;
    private Vector3 storePos; //stores the rotation of the attached gameObject

    // Use this for initialization
    void Start() {
        myCamera = GetComponent<Camera>();
        storePos = gameObject.transform.eulerAngles;  //keeps storePos up to date 
    }

    // Update is called once per frame
    void Update() {
        rot = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime * RotationSpped;

        if (rot != 0) {
            storePos = new Vector3(Mathf.Clamp(storePos.x + rot, MinXRotation, MaxXRotation), storePos.y, storePos.z);
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

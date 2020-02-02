using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        transform.LookAt(Vector3.zero, Vector3.forward);
        transform.Rotate(new Vector3(-90, 0, 0), Space.Self);
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

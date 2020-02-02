using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBehaviour : MonoBehaviour
{
    
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        transform.position = GetComponentInParent<Transform>().position;
        rb.AddForce(GetComponentInParent<Transform>().eulerAngles/100, ForceMode.Impulse);
        
        Destroy(this.gameObject,10f);
    }
}

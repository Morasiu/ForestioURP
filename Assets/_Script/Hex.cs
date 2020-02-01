using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public HexState HexState { get; private set; }
    public Dictionary<NeighbourDirection, GameObject> Neighbours;

    // Start is called before the first frame update
    void Start()
    {
        Neighbours = new Dictionary<NeighbourDirection, GameObject>();
        HexState = HexState.Neutral;

        //for (int i = 0; i < Enum.GetValues(typeof(NeighbourDirection)).Length; i++) {
        //    Vector3 direction = transform.TransformDirection(Vector3.back) * 5;
        //    if (Physics.Raycast(transform.position, direction, out var hit, 20)) {
        //        Debug.Log("Hit: " + hit.collider.name);
        //    }
        //}

        //Debug.Log(Neighbours.Count);
    }

    //void OnDrawGizmosSelected() {
    //    // Draws a 5 unit long red line in front of the object
    //    Gizmos.color = Color.red;
    //    Vector3 direction = transform.TransformDirection(Vector3.back) * 5;
    //    Gizmos.DrawRay(transform.position, direction * 5);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

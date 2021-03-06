﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Hex : MonoBehaviour
{
    public Dictionary<NeighbourDirection, GameObject> Neighbours;
    public bool isNonActive;
    public bool isPolluted;
    public bool isNatural;

    List<Material> materials;

    [SerializeField]
    private HexState status;

    public HexState Status
    {
        get { return status; }
        set {
            if (value == HexState.NonActive)
            {
                value = HexState.NonActive;
                // GetComponent<MeshRenderer>().material = materials[0];         ----mmozna nazlozyc swoj material woda piasek etc
            }
            else if (value == HexState.Polluted)
            {
                value = HexState.Polluted;
                GetComponent<MeshRenderer>().material = materials[1];
            }
            else if (value == HexState.Natural)
            {
                value = HexState.Natural;
                GetComponent<MeshRenderer>().material = materials[2];
            }
            else
            {
                value = HexState.Neutral;
                GetComponent<MeshRenderer>().material = materials[3];
            }

            status = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Neighbours = new Dictionary<NeighbourDirection, GameObject>();
        materials = GetComponentInParent<WorldMaterials>().materials.ToList();
        
        if (isNonActive)
        {
           status = HexState.NonActive;
           GetComponent<MeshRenderer>().material = materials[0];         
            // ----mmozna nazlozyc swoj material woda piasek etc
        } else if (isPolluted)
        {
            status = HexState.Polluted;
            GetComponent<MeshRenderer>().material = materials[1];
        }
        else if (isNatural)
        {
            status = HexState.Natural;
            GetComponent<MeshRenderer>().material = materials[2];
        }
        else
        {
            status = HexState.Neutral;
            GetComponent<MeshRenderer>().material = materials[3];
        }

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

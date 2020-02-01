using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Hex : MonoBehaviour
{
    public HexState HexState { get; private set; }
    public List<GameObject> Neighbours;
    public bool isNonActive;
    public bool isPolluted;
    public bool isNatural;
    
    // Start is called before the first frame update
    void Start()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
        Neighbours = hitColliders.Where(c => c.GetComponent<Hex>() != null).Select(c => c.gameObject).ToList();

        var materials = GetComponentInParent<WorldMaterials>().materials.ToList();
        
        if (isNonActive)
        {
            HexState = HexState.NonActive;
           // GetComponent<MeshRenderer>().material = materials[0];         ----mmozna nazlozyc swoj material woda piasek etc
        }else if (isPolluted)
        {
            HexState = HexState.Polluted;
            GetComponent<MeshRenderer>().material = materials[1];
        }
        else if (isNatural)
        {
            HexState = HexState.Natural;
            GetComponent<MeshRenderer>().material = materials[2];
        }
        else
        {
            HexState = HexState.Neutral;
            GetComponent<MeshRenderer>().material = materials[3];
        }

        Debug.Log(Neighbours.Count);
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

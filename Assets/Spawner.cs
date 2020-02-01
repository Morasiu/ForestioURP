using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            //child is your child transform
            Instantiate(ToSpawn, child, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

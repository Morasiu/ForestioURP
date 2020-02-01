using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactoryAI : MonoBehaviour
{
    [SerializeField]
    private float FactorySpawnTime = 3f;
    List<Hex> HexList;

    IEnumerator Start()
    {
        HexList = FindObjectsOfType<Hex>().ToList();
        //Debug.Log(HexList.Count);
        while (true) {
            yield return new WaitForSeconds(FactorySpawnTime);
            // Change to filter already taken fields.
            var freeHexList = HexList;

            var randomIndex = Random.Range(0, freeHexList.Count);
            var spawnParent = HexList[randomIndex];
            // TODO
            Debug.Log("TODO. Spawn new factory here: " + spawnParent.name);
        }

    }

    void Update()
    {
        
    }
}

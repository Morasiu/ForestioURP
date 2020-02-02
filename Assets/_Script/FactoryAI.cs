using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactoryAI : MonoBehaviour
{

    public GameObject FactoryPrefab;

    [SerializeField]
    private float FactorySpawnTime = 3f;

    private float FactorySpeedUp = 0.1f;
    List<Hex> HexList;

    IEnumerator Start()
    {
        HexList = FindObjectsOfType<Hex>().ToList();
        //Debug.Log(HexList.Count);
        while (true) {
            var factoryNumber = FindObjectsOfType<Factory>().Length;
            if (factoryNumber == 0) factoryNumber = 1;
            FactorySpawnTime = 3f - factoryNumber * FactorySpawnTime;
            // Change to filter already taken fields.
            //var freeHexList = HexList.FirstOrDefault(h => h.Status == HexState.Neutral);
            var hex = HexList.FirstOrDefault(h => h.Status == HexState.Neutral);
            var factoryTime = FindObjectsOfType<Factory>().Length;

            //var randomIndex = Random.Range(0, freeHexList.Count() -1);
            //var spawnParent = HexList[randomIndex];
            // TODO
            if (hex == null) break;
            Instantiate(FactoryPrefab, hex.transform, false);
            Debug.Log($"Spawned factory at: {hex.name}");
            //Instantiate(FactoryPrefab, spawnParent.transform, false);
            yield return new WaitForSeconds(FactorySpawnTime);
        }

    }

    void Update()
    {
        
    }
}

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
            FactorySpawnTime = Mathf.Clamp(3f - factoryNumber * FactorySpeedUp, 0.1f, 5);
            var spawnParent = HexList.FirstOrDefault(h => h.Status == HexState.Neutral);

            // Change to filter already taken fields.
            //var freeHexList = HexList.Where(h => h.Status == HexState.Neutral);
            //var randomIndex = Random.Range(0, freeHexList.Count() - 1);
            //var spawnParent = HexList[randomIndex];

            // TODO
            if (spawnParent == null) {
                Debug.Log("No more hex! :o");
                break;
            }

            Instantiate(FactoryPrefab, spawnParent.transform, false);
            Debug.Log($"Spawned factory at: {spawnParent.name}");
            //Instantiate(FactoryPrefab, spawnParent.transform, false);
            yield return new WaitForSeconds(FactorySpawnTime);
        }

    }

    void Update()
    {
        
    }
}

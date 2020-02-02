using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CometManager : MonoBehaviour
{
    List<GameObject> cometHandlers;
    private void Start()
    {
        cometHandlers = GameObject.FindGameObjectsWithTag("CometHandler").ToList();
        StartCoroutine(CometSpawner());
    }
    IEnumerator CometSpawner()
    {
        while (true)
        {
            foreach (var comet in cometHandlers)
            {
                yield return new WaitForSeconds(Random.Range(2f, 5f));
                comet.GetComponent<CometHandler>().SpawnComet();
            }
        }
    }
}

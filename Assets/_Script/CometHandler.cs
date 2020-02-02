using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometHandler : MonoBehaviour
{
    public GameObject CometPrefab;
    public void SpawnComet()
    {
        Instantiate(CometPrefab, transform, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BarManager : MonoBehaviour
{
    List<Hex> HexaList;
    List<Hex> GoodHexas;
    List<Hex> BadHexas;
    ProgressBar progressBar;
    void Start()
    {
        HexaList = FindObjectsOfType<Hex>().ToList<Hex>();
        progressBar = FindObjectOfType<ProgressBar>();
    }

    private void Update()
    {
        var naturalHexa = HexaList.Sum(x => x.HexState.CompareTo(HexState.Natural));
        var poluttedHexa = HexaList.Sum(x => x.HexState.CompareTo(HexState.Polluted));

        float percentage = (float)(naturalHexa / poluttedHexa);
        progressBar.targetPercentage = percentage;
    }


}

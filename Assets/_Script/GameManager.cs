using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    List<Hex> HexaList;

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

        if (naturalHexa == 0) {
            Debug.Log("POLLUTION WON! :(");
            return;
        } else if (poluttedHexa == 0) {
            Debug.Log("NATURE WON! :)");
            return;
        }

        float percentage = (float)(naturalHexa / poluttedHexa);
        progressBar.targetPercentage = percentage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

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
        var naturalHexa = HexaList.Count(x => x.Status == HexState.Natural);
        var poluttedHexa = HexaList.Count(x => x.Status == HexState.Polluted);

        //if (naturalHexa == 0) {
        //    GoToLoseGameScene();
        //    return;
        //} else if (poluttedHexa == 0) {
        //    GoToWonGameScene();
        //    return;
        if (!FindObjectsOfType<Hex>().Any(h => h.Status == HexState.Neutral)){
            Debug.Log("No more neutral HEX!");
            if (naturalHexa > poluttedHexa)
                GoToWonGameScene();
            else
                GoToLoseGameScene();
            return;

        }

        float raw = ((float) naturalHexa / (poluttedHexa + naturalHexa));
        float width = progressBar.o2Bar.transform.parent.GetComponent<RectTransform>().rect.width;
        float percentage = raw * width;
        progressBar.targetPercentage = percentage;
    }

    private static void GoToWonGameScene() {
        Debug.Log("NATURE WON! :)");
        SceneManager.LoadScene("EndGameWon");
    }

    private static void GoToLoseGameScene() {
        Debug.Log("POLLUTION WON! :(");
        SceneManager.LoadScene("EndGameLose");
    }
}

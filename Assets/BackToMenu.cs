using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BackToMenu : MonoBehaviour
{
    private VideoPlayer player;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += GoToMainMenu;
    }

    private void GoToMainMenu(VideoPlayer source) {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameMenu;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    //Button Functions
    public void Play()
    {
        if (gameEnums.gameStatusCache == gameEnums.gameStatus.NONE)
        {
            gameMenu.SetActive(false);
            Time.timeScale = 1f;
            gameEnums.gameStatusCache = gameEnums.gameStatus.PLAYING;
        }

        else if (gameEnums.gameStatusCache == gameEnums.gameStatus.ENDGAME)
        {
            gameEnums.gameStatusCache = gameEnums.gameStatus.NONE;
            SceneManager.LoadScene(0);
        }
    }

    public void  Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject gameMenu,rankText;


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
            rankText.SetActive(true);
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

    //button function end
}

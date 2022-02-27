using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //public static UiManager Instance;
    public Text percentText;
    public GameObject Menu,rankText;

    private void LateUpdate()
    {
        if (gameEnums.gameStatusCache == gameEnums.gameStatus.ENDGAME)
        {
            if(rankText.activeInHierarchy == true)
            {
                rankText.SetActive(false);
            }
            percentageController.percentCalculator();
            wallGameUi();
        }

        if(percentageController.percent == 100)
        {
            Menu.gameObject.SetActive(true);
        }
    }

    public void wallGameUi()
    {
        float percentCacher = percentageController.percent;
        if (percentText.gameObject.activeInHierarchy == true)
        {
              percentText.text = "%" + percentCacher.ToString();
        }
        else
        {
            percentText.gameObject.SetActive(true);
        }
    }
}

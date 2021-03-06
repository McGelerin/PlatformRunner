using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //public static UiManager Instance;

    [Header ("Game Objects")]
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
            wallGameUi();
        }

        if(objectDraw.percent == 100)
        {
            Menu.gameObject.SetActive(true);
        }
    }


    //Percentage UI Writer
    public void wallGameUi()
    {
        float percentCacher = objectDraw.percent;
        if (percentText.gameObject.activeInHierarchy == true)
        {
            percentText.text = "%" + (((int)percentCacher).ToString());
        }
        else
        {
            percentText.gameObject.SetActive(true);
        }
    }
}

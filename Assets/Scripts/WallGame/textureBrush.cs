using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureBrush : MonoBehaviour
{
    private void OnMouseEnter()
    {
        if(gameEnums.gameStatusCache == gameEnums.gameStatus.ENDGAME)
        if (gameObject.GetComponent<Renderer>().material.color != Color.red)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            percentageController.paintedArea += 1;
        }
    }
}

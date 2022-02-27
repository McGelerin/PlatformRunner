using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class percentageController : MonoBehaviour
{
    public static float paintedArea,percent,areaPiece;

    public UiManager ui;

    private void Start()
    {
        paintedArea = 0;
        areaPiece = this.gameObject.transform.childCount;
        percent = 0;
    }
    public static void percentCalculator()
    {
        percent = (paintedArea / areaPiece) * 100;
    }


}

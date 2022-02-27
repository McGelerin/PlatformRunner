using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEnums : MonoBehaviour
{
    public static gameStatus gameStatusCache;

    private void Start()
    {
        gameStatusCache = gameStatus.NONE;
    }

    public enum gameStatus
    {
        NONE,
        PLAYING,
        ENDGAME
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    [Header("User Variables")]
    public bool isUserHoldScreen;


    [Header("Scrips Variables")]
    private float lastFrameFingerPositionX;
    private float moveFactorX;

    public float MoveFactorX => moveFactorX;
    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        lastFrameFingerPositionX = Input.mousePosition.x;
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
    //        lastFrameFingerPositionX = Input.mousePosition.x;
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        moveFactorX = 0f;
    //    }
    //}

    public void ChechTouches()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isUserHoldScreen = true;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isUserHoldScreen = false;
            moveFactorX = 0f;
        }
    }
}

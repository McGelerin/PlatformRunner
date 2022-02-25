using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    [Header("User Variables")]
    public bool isUserHoldScreen;

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        _lastFrameFingerPositionX = Input.mousePosition.x;
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
    //        _lastFrameFingerPositionX = Input.mousePosition.x;
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        _moveFactorX = 0f;
    //    }
    //}

    public void ChechTouches()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isUserHoldScreen = true;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isUserHoldScreen = false;
            _moveFactorX = 0f;
        }
    }
}

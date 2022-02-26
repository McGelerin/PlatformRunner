using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class rotateWaySc : MonoBehaviour
{
    [Header("Rotate Way")]
    public rotateWay rotateWay;
    public float rotateSpeed;

    [Header("Variables")]
    private float angularSpeedx = 0, angularSpeedy = 0, angularSpeedz = 0;
    private Rigidbody platformRB;

    private void Awake()
    {
        platformRB = GetComponent<Rigidbody>();
        rotateWay selectedRotate = rotateWay;

        if (selectedRotate == rotateWay.xRotate)
        {
            angularSpeedx = rotateSpeed;
        }
        else if (selectedRotate == rotateWay.yRotate)
        {
            angularSpeedy = rotateSpeed;
        }
        else if (selectedRotate == rotateWay.zRotate)
        {
            angularSpeedz = rotateSpeed;
        }
    }

    void Start()
    {
        RotateMyRing();
    }

    void RotateMyRing()
    {
        platformRB.DORotate(new Vector3(angularSpeedx, angularSpeedy, angularSpeedz), 1)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }
}

[System.Serializable]
public enum rotateWay
{
    xRotate,
    yRotate,
    zRotate,
}
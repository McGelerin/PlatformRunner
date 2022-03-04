using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG;

public class orientationFuntion : MonoBehaviour
{
    public Rigidbody rb;
    private SwerveInputSystem swerveInputSystem;

    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }


    private void Update()
    {
        if (swerveInputSystem.MoveFactorX > 0)
        {
            Orientation_R();
        }
        else if (swerveInputSystem.MoveFactorX < 0)
        {
            Orientation_L();
        }
        else Orientation_Default();

    }

    public void Orientation_R()
    {
        rb.DORotate(new Vector3(0,50,0), 1f).SetEase(Ease.Linear);
    }
    public void Orientation_Default()
    {
        rb.DORotate(new Vector3(0, 0, 0), 2).SetEase(Ease.Linear);
    }
    public void Orientation_L()
    {
        rb.DORotate(new Vector3(0, -50, 1), 1f).SetEase(Ease.Linear);
    }

}

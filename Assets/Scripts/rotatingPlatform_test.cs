using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotatingPlatform_test : MonoBehaviour
{
    public float angularSpeed;
    private Rigidbody platformRB;
    Vector3 m_EulerAngleVelocity;

    private void Awake()
    {
        platformRB = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        //m_EulerAngleVelocity = new Vector3(0, 0, donme_hizi);

        RotateMyRing();
    }

    void RotateMyRing()
    {
        platformRB.DORotate(new Vector3(0, 0, angularSpeed), 1)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
            //.OnComplete( ()=> { RotateMyRing(); } );
    }

    //void FixedUpdate()
    //{
    //    Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
    //    platformfizik.MoveRotation(platformfizik.rotation * deltaRotation);
    //}
}

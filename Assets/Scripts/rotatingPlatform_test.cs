using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingPlatform_test : MonoBehaviour
{
    public float donme_hizi;
    private Rigidbody platformfizik;
    Vector3 m_EulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
        platformfizik = GetComponent<Rigidbody>();

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(0, 0, donme_hizi);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        platformfizik.MoveRotation(platformfizik.rotation * deltaRotation);
    }
}

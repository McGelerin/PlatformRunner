using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [SerializeField] private float maxMove_x = 1f;
    [SerializeField] private Rigidbody playerfizik;




    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    //private void FixedUpdate()
    //{

    //    float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
    //    swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
    //    //transform.Translate(swerveAmount, 0, 0);
    //    playerfizik.velocity = new Vector3(swerveAmount, playerfizik.velocity.y, playerfizik.velocity.z);
    //}

    public void SwerveMove()
    {

        float swerveAmount = /*Time.deltaTime**/ swerveSpeed * swerveInputSystem.MoveFactorX; 
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount); //Kelepçeleme
        Debug.Log(swerveAmount);

        if (edgeController())
        {
            playerfizik.velocity = new Vector3(swerveAmount, 0, 0);
        }
    }

    public bool edgeController()
    {
        if (playerfizik.transform.position.x <= maxMove_x && playerfizik.transform.position.x >= -maxMove_x)
        {
            return true;
        }
        else if (playerfizik.position.x > maxMove_x)
        {
            playerfizik.transform.position = new Vector3(maxMove_x, playerfizik.position.y, playerfizik.position.z);
        }
        else if(playerfizik.position.x < -maxMove_x)
        {
            playerfizik.transform.position = new Vector3(-maxMove_x, playerfizik.position.y, playerfizik.position.z);
        }
        return false;
    }
}

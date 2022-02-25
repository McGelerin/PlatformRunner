using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    private Rigidbody playerfizik;

    void Start()
    {
        playerfizik = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void FixedUpdate()
    {

        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        //transform.Translate(swerveAmount, 0, 0);
        playerfizik.velocity = new Vector3(swerveAmount, playerfizik.velocity.y, playerfizik.velocity.z);
    }
}

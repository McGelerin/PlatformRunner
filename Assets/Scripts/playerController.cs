using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance; //Singleton(Tek Nesne) Dýþardan eriþim için

    [Header("Player Component")]
    private Rigidbody playerRB;
    private Animator anim;

    [Header("Needed Scripts")]
    SwerveMovement swerveMoveSC;
    SwerveInputSystem swerveInputSC;

    [Header("Player Variables")]
    public float movementSpeed;
    //public float rotatorKuvvet;
    

    private void Awake()
    {
        Instance = this; //Singleton(Tek Nesne) Dýþardan eriþim için
        swerveMoveSC = FindObjectOfType<SwerveMovement>();
        swerveInputSC = FindObjectOfType<SwerveInputSystem>();
        playerRB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    //void Start()
    //{

    //}

    private void Update()
    {
        swerveInputSC.ChechTouches();

        if (swerveInputSC.isUserHoldScreen)//(Input.GetMouseButton(0)) // mousebuttondown 1 kere calýþýr
        {
            anim.SetTrigger("move2"); //sürekli yeniden baþlýyor
            //anim.SetBool("move", true);
            hareket();
        }
        else if (!swerveInputSC.isUserHoldScreen)//(Input.GetMouseButtonUp(0))
        {
            anim.ResetTrigger("move2");
        }        
        

        //else { anim.SetBool("move", false); }
        //hareket();

    }

    private void FixedUpdate()
    {
        swerveMoveSC.SwerveMove();
    }

    private void hareket()
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y, movementSpeed);
        //anim.SetBool("move", true);
        //playerfizik.AddForce(Vector3.forward * hareket_hizi * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeathArea")
        {
            death();
        }
    }


    // --------------------GEREK KALMADI-------------- RIG ÝLE YAPILDI

    //public void OnTriggerStay(Collider col)
    //{
    //    if (col.gameObject.tag == "lRotate")
    //    {
    //        Debug.Log("rotate girdi");
    //        playerfizik.velocity = new Vector3( -rotatorKuvvet , playerfizik.velocity.y, playerfizik.velocity.z);
    //    }

    //    if (col.gameObject.tag == "rRotate")
    //    {
    //        Debug.Log("rotate girdi");
    //        playerfizik.velocity = new Vector3( rotatorKuvvet, playerfizik.velocity.y, playerfizik.velocity.z);
    //    }
    //}


    public void death()
    {
        transform.DOMove( Vector3.zero, .3f );//transform.position = new Vector3(0f, 0f, 0f); 
    }
}

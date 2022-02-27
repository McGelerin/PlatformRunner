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

    [Header("Wall Game")]
    public GameObject wallTarget;
    private bool endGameCache;

    private void Awake()
    {
        Instance = this; //Singleton(Tek Nesne) Dýþardan eriþim için
        swerveMoveSC = FindObjectOfType<SwerveMovement>();
        swerveInputSC = FindObjectOfType<SwerveInputSystem>();
        playerRB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        endGameCache = false;
    }

    private void Update()
    {
        if (!endGameCache)
        {
            swerveMoveSC.SwerveMove();
            swerveInputSC.ChechTouches();

            if (swerveInputSC.isUserHoldScreen)//(Input.GetMouseButton(0)) // mousebuttondown 1 kere calýþýr
            {
                //anim.SetTrigger("move2"); //sürekli yeniden baþlýyor
                anim.SetBool("move", true);
                hareket();
            }
            else //if(!swerveInputSC.isUserHoldScreen) //(Input.GetMouseButtonUp(0))
            {
                anim.SetBool("move", false);
                //anim.ResetTrigger("move2");
            }
        }

    }

    //private void FixedUpdate()
    //{
        
    //}

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
        if (col.gameObject.tag == "Finish")
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        endGameCache = true;
        transform.DOMove(wallTarget.transform.position, 2f);
        anim.SetBool("move", false);
        gameEnums.gameStatusCache = gameEnums.gameStatus.ENDGAME;
    }


    public void death()
    {
        transform.DOMove( Vector3.zero, .1f );//transform.position = new Vector3(0f, 0f, 0f); 
    }
}

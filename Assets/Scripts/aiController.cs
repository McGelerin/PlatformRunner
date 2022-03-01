using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiController: MonoBehaviour
{
    [Header ("Components Access")]
    private Animator anim;
    NavMeshAgent agent;
    public GameObject hedef;
    //private PlayerController PlayerController;
   // private CapsuleCollider col;
   
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        // col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //agent.destination = hedef.transform.position;
        agent.SetDestination(hedef.transform.position);
    }

    void Update()
    {
        //agent.SetDestination(hedef.transform.position);
        //agent.Move(hedef.transform.position);
        //agent.destination = hedef.transform.position;


        aiAnim();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeathArea")
        {
            death();
        }
        
    }

    private void aiAnim()
    {
        if(agent.velocity.magnitude <= .2f)
        {
            anim.SetBool("move", false);
        }
        else anim.SetBool("move", true);

    }

    public void death()
    {
        transform.DOMove(Vector3.zero, .1f);//transform.position = new Vector3(0f, 0f, 0f); 
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiController: MonoBehaviour
{
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


    void Update()
    {
        agent.SetDestination(hedef.transform.position);
        aiAnim();
        // OnTriggerEnter()

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
        Debug.Log("Ainim girdi");
        if(agent.velocity.magnitude <= .2f)
        {
            Debug.Log("Ainim girdi");
            anim.SetBool("move", false);
        }
        else anim.SetBool("move", true);

    }

    public void death()
    {
        transform.DOMove(Vector3.zero, .3f);//transform.position = new Vector3(0f, 0f, 0f); 
    }
}

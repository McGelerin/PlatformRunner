using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class horizontalObstacle : MonoBehaviour
{
    private Rigidbody obstacleRB;
    public float movementSpeed;
    private bool rmove = true;

    void Start()
    {
        obstacleRB = GetComponent<Rigidbody>();

        MoveRight();
    }

    void MoveRight()
    {
        obstacleRB.DOMoveX( .4f, movementSpeed )
            .SetEase( Ease.Linear )
            .OnComplete( ()=>
            {
                MoveLeft();
            });
    }

    void MoveLeft()
    {
        obstacleRB.DOMoveX( -.4f, movementSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                MoveRight();
            });
    }

    //void Update()
    //{
    //    if (transform.position.x < 0.4f && rmove == true)
    //    {
    //        rightMove();
    //    }
    //    else if (transform.position.x > 0.4f) {
    //        rmove = false;
    //    }
    //    if (transform.position.x > -0.4f && rmove == false)
    //    {
    //        leftMove();
    //    }
    //    else if (transform.position.x < -0.4f)
    //    {
    //        rmove = true;
    //    }
    //}

    //private void rightMove()
    //{
    //    obstaclefizik.velocity = new Vector3(hareket_hizi, obstaclefizik.velocity.y, obstaclefizik.velocity.z);
    //}
    //private void leftMove()
    //{
    //    obstaclefizik.velocity = new Vector3(-hareket_hizi, obstaclefizik.velocity.y, obstaclefizik.velocity.z);
    //}
}

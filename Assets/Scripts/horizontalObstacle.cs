using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalObstacle : MonoBehaviour
{
    private Rigidbody obstaclefizik;
    public float hareket_hizi;
    private bool rmove = true;

    // Start is called before the first frame update
    void Start()
    {
        obstaclefizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0.4f && rmove == true)
        {
            rightMove();
        }
        else if (transform.position.x > 0.4f) {
            rmove = false;
        }
        if (transform.position.x > -0.4f && rmove == false)
        {
            leftMove();
        }
        else if (transform.position.x < -0.4f)
        {
            rmove = true;
        }
    }

    private void rightMove()
    {
        obstaclefizik.velocity = new Vector3(hareket_hizi, obstaclefizik.velocity.y, obstaclefizik.velocity.z);
    }
    private void leftMove()
    {
        obstaclefizik.velocity = new Vector3(-hareket_hizi, obstaclefizik.velocity.y, obstaclefizik.velocity.z);
    }
}

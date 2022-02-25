using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcterController_test : MonoBehaviour
{
    public CapsuleCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeathArea")
        {
            Debug.Log("icerri girdi");
            death();
        }
    }

    private void death()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }
}

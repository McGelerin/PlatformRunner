using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawFunction : MonoBehaviour
{
    public GameObject Brush;
    public float BrushSize = .1f;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                var go = Instantiate(Brush, hit.point + Vector3.up * .1f, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize; 
            }


        }
    }




}

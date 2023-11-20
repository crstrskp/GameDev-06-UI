using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapSphereExample : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RunExample();
            RunExampleRayCast();
        }
    }

    private void RunExampleRayCast()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);

            // Giv skade. 
        }
    }

    private void RunExample()
    {
        var colliders = Physics.OverlapSphere(transform.position, 10f);

        foreach (Collider c in colliders)
        {
            Debug.Log(c.name);
        }

    }



}

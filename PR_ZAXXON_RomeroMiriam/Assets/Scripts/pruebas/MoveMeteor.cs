using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteor : MonoBehaviour
{

    public float desplSpeed = 2f;

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * desplSpeed);
    }

   
}
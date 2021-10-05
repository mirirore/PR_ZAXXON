using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteor : MonoBehaviour
{

    public float desplSpeed = 20f;

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * desplSpeed);

        //Destruir objeto si pasa de los limites de mi camara
        float posZ = transform.position.z;

        if (posZ < -1)
        {
            Destroy(gameObject);
        }
    }

   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverNave : MonoBehaviour
{
    public float desplSpeed = 30f;
   
    // Update is called once per frame
    void Update()
    {
        float DesplY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * DesplY * Time.deltaTime * desplSpeed, Space.World);


        float DesplX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * DesplX * Time.deltaTime * desplSpeed, Space.World);

        
        float Rotar = Input.GetAxis("Horizontal") * desplSpeed;
        transform.Rotate(Vector3.back * Rotar * Time.deltaTime * desplSpeed);


        //RESTRICCION

        // Desplazamiento Horizontal

          if (transform.position.x >= 10)
        {
            transform.position = new Vector3(10f, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
        }

        // Desplazamiento Vertical

        if (transform.position.y >= 5)
        {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
        }

        if (transform.position.y <= -1)
        {
            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
        }

        //Rotate

      

    }



}

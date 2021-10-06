using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocimetro : MonoBehaviour
{

    bool moving = true;
    float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }




    // Update is called once per frame
    void Update()
    {
        float tiempoTranscurrido = Time.time;

        if (moving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (tiempoTranscurrido >= 60)
        {
            moving = false;
            float posZ = transform.position.z / 10000;
            print("Te mueves a una velocidad de" + posZ + "Km/min");
            // Para ver si a los 10 segundos paraba la capsula print ("tiempo transcurrido"+Time.time);
            //print("Distancia recorrida"+ transform.position.z);
        }

        //print(Time.time);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverNave : MonoBehaviour
{
    InitGame initGame;

    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameScript").GetComponent<InitGame>();

    }


    // Update is called once per frame
    void Update()
    {

        Movimiento();
        

      

    }
    //Rotate

    void Movimiento()
    {
        float DesplY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * DesplY * Time.deltaTime * initGame.speed, Space.World);


        float DesplX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * DesplX * Time.deltaTime * initGame.speed, Space.World);


       /* float Rotar = Input.GetAxis("Horizontal") * desplSpeed;
        transform.Rotate(Vector3.back * Rotar * Time.deltaTime * desplSpeed);*/


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
    }

}

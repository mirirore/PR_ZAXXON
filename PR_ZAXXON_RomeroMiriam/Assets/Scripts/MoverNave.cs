using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverNave : MonoBehaviour
{
    InitGame initGame;

    //Rotacion angle
   float RotAng = 40f;

    /*----------Particulas------------*/
    // variable Chocar
    public GameObject sparksParticle;
    


    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();

    }

    // Update is called once per frame
    void Update()
    {

        Movimiento();
       Rotacion();
        
    }
    

    void Movimiento()
    {
        float DesplY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * DesplY * Time.deltaTime * initGame.speed, Space.World);


        float DesplX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * DesplX * Time.deltaTime * initGame.speed, Space.World);


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

        if (transform.position.y >= 4)
        {
            transform.position = new Vector3(transform.position.x, 4f, transform.position.z);
        }

        if (transform.position.y <= -1)
        {
            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
        }
    }

   void Rotacion()
    {
        // Posicion y Quaternion

        float rotZ = Input.GetAxis("Horizontal") * RotAng;
        

        Quaternion rotar = Quaternion.Euler(0, 0, rotZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotar, Time.deltaTime);

    }
   

    //Destruir nave
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "obstaculo")
        {
            //posicion e instancia particulas choque
            
            GameObject sparksClone = Instantiate(sparksParticle, transform.position, Quaternion.identity) as GameObject;
            Destroy(sparksClone, 2);

            initGame.SendMessage("Chocar");
           
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    
    InitGame initGame;

    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * initGame.speed);

       
        //Destruir objeto si pasa de los limites de mi camara
        float posZ = transform.position.z;

        if (posZ < -10)
        {
            Destroy(gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObs : MonoBehaviour
{
    InitGame initGame;

    //variables instanciacion
    float intervalo;
    [SerializeField] float distEntreObs;
    [SerializeField] Transform InitPos;
    int contadorPowerUp =5;
    
    //Array obstaculos
    [SerializeField] GameObject[] arrayObst;

    

    //Variable cambio de nivel
    int level;

    


    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();

        distEntreObs = 3f;
        
        StartCoroutine("RandomObs");


    }



    IEnumerator RandomObs()
    {
        

        while (true)
        {
            //Posición instanciación obstaculos

            float aleatorioX = Random.Range(-9, 10);
            float aleatorioY = Random.Range(-1, 6);
            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, InitPos.position.z);
            
            int randomNum;
            
            
            level = initGame.levelGame;
            
            //Según el nivel
            if (level == 0)
            {
                randomNum = Random.Range(0,2);
                
                
            }
            else if (level > 0 && level < 5)
            {
                randomNum = Random.Range(0, 3);
                
            }
            else
            {
                randomNum = Random.Range(0, arrayObst.Length);
                
            }

            if (arrayObst[randomNum].CompareTag("PowerUp"))
            {
                if (contadorPowerUp == 10)
                {
                    newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);
                    Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);
                    contadorPowerUp = 0;
                }
                else
                {
                    contadorPowerUp++;
                }


            }

            else
            {
                //Obstaculo en base a la velocidad
                intervalo = distEntreObs / initGame.speed;


                // Instancia prefab aleatorio 
                Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);

                
            }

            
            yield return new WaitForSeconds(intervalo);

        }

       
    }



   public void PararInstancia()
    {

        StopCoroutine("RandomObs");
    }
   
}

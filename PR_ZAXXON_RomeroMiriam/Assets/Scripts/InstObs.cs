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

    //Array Background
    [SerializeField] GameObject[] arrayBG;

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
            //Posici�n instanciaci�n obstaculos

            float aleatorioX = Random.Range(-9, 10);
            float aleatorioY = Random.Range(-1, 6);
            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, InitPos.position.z);
            
            int randomNum;
            int randomBG;
            
            level = initGame.levelGame;
            
            //Seg�n el nivel
            if (level == 0)
            {
                randomNum = Random.Range(0,2);
                randomBG = 0;
                
            }
            else if (level > 0 && level < 5)
            {
                randomNum = Random.Range(0, 3);
                randomBG = Random.Range(0, 2);
            }
            else
            {
                randomNum = Random.Range(0, arrayObst.Length);
                randomBG = Random.Range(0, 3);
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

                Instantiate(arrayBG[randomBG], transform.position, Quaternion.identity);
            }

            
            yield return new WaitForSeconds(intervalo);

        }

       
    }



   public void PararInstancia()
    {

        StopCoroutine("RandomObs");
    }
   
}

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

    
    //Array obstaculos
    [SerializeField] GameObject[] arrayObst;

    //Variable cambio de nivel
    int level;

    //Array Power Up
    [SerializeField] GameObject[] powerUp;


    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();

        distEntreObs = 5f;

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
                randomNum = 0;
            }
            else if (level > 0 && level < 5)
            {
                randomNum = Random.Range(0, 2);
            }
            else
            {
                randomNum = Random.Range(0, arrayObst.Length);
            }

            

            //Obstaculo en base a la velocidad
            intervalo = distEntreObs / initGame.speed;
            

            // Instancia prefab aleatorio 
            Instantiate(arrayObst[randomNum], newPos, Quaternion.identity);


            /* Instancia POWER UPS POSICION
            float instPowerUpX = Random.Range(-9f, 10f);
            float instPowerUpY = Random.Range(-1f, 6f);


            Vector3 PowerUpPos = new Vector3(instPowerUpX, instPowerUpY, InitPos.position.z);

            //Power Ups salen random
            int randomPowerUp = Random.Range(0, 2);

            //los powerUps se instancian en una posicion diferente a la de los obstaculos
           if (PowerUpPos != newPos)
            {
                
                Instantiate(powerUp[randomPowerUp], PowerUpPos, Quaternion.identity);
                
            }*/

            

            yield return new WaitForSeconds(intervalo);

        }

       
    }

   public void PararInstancia()
    {

        StopCoroutine("RandomObs");
    }
   
}

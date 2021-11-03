using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObs : MonoBehaviour
{
    //[SerializeField] GameObject obstaculo;



    float intervalo;

    [SerializeField] float distEntreObs;

    InitGame initGame;

    [SerializeField] GameObject[] arrayObst;

    int level;



    


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
            //Posición instanciación

            float aleatorioX = Random.Range(-9, 10);
            float aleatorioY = Random.Range(-1, 6);
            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);

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

            yield return new WaitForSeconds(intervalo);

        }

       
    }

   public void PararInstancia()
    {

        StopCoroutine("RandomObs");
    }
   
}

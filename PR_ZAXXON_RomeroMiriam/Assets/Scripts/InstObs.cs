using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObs : MonoBehaviour
{
    [SerializeField] GameObject obstaculo;

    float intervalo;

    [SerializeField] float distEntreObs;

  
    InitGame initGame;


    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameScript").GetComponent<InitGame>();

        distEntreObs = 10f;

        intervalo = distEntreObs / initGame.speed;

        StartCoroutine("RandomObs");

    }

   

    IEnumerator RandomObs()
    {


        for (int n = 0; ; n++)
        {
            float aleatorioX = Random.Range(-9, 10);
            float aleatorioY = Random.Range(-1, 6);
            Vector3 newPos = new Vector3(aleatorioX, aleatorioY, transform.position.z);
            Instantiate(obstaculo, newPos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);

        }



    }
}

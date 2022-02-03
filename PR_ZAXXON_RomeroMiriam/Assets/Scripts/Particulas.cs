using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    InitGame initGame;
    
    //Variable cambio de nivel
    int level;

    //Array Background
    [SerializeField] GameObject[] arrayBG;

    //Posicion instanciador
    [SerializeField] Transform backgPos;

    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();


        StartCoroutine("RandomBG");
    }

    IEnumerator RandomBG()
    {

        

        while (true)
        {

            int randombg;

            level = initGame.levelGame;

            //Segun el nivel
            
            if (level == 0)
            {

                randombg = 0;
            }
            else if (level > 0 && level < 4)
            {
                randombg = Random.Range(0, 2);

            }
            else
            {

                randombg = Random.Range(0,arrayBG.Length);
            }

            Vector3 newPosBG = new Vector3(backgPos.position.x, backgPos.position.y, backgPos.position.z);
            Instantiate(arrayBG[randombg], newPosBG, Quaternion.identity);

            yield return new WaitForSeconds(0.1f);

        }


    }

    public void PararBG()
    {

        StopCoroutine("RandomBG");
    }
}

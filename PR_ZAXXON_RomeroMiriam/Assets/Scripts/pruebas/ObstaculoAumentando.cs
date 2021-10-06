using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoAumentando : MonoBehaviour
{
    //VaIABLE QUE INDICA EL NIVEL (deberia estar en el InitGame Script)

    int levelGame = 1;

    // En el Script de instanciar
    int level = 1;
    InitGameScript initGameScript;


    // Start is called before the first frame update
    void Start()
    {
        // Lo de los niveles, en el script de instanciar
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Aumentar obstáculos según paso de nivel

    int randomNum = 0;
   level= initGameScript.levelGame; //En cada ciclo de la corrutina consulta en que nivel estoy

    if(level==0)
        {
        int randomNum = 0;
        }
     else if (level > 0 && level<5)
{ 
    int randomNum = Random.Range(0, 5); 
}
     else (level>=5)
  {
    int randomNum = Random.Range(0,//Array);
}

/*crear variable flota intervalo
en la corrutina el yield return WaitForEndOfFrame for seconds(ontervall)


}

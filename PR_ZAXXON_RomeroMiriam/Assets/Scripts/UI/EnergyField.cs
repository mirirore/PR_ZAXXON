using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyField : MonoBehaviour
{
    InitGame initGame;

    [SerializeField] Slider escudoEnergy;

    public bool loaded;

    public bool shield;

    // Start is called before the first frame update
    void Start()
    {

        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();
        escudoEnergy.value = 0f;
        loaded = false;
        shield = false;
    }

    // Update is called once per frame
    void Update()
    {

        BarraEscudo();
       
       
       
    }


    public void BarraEscudo()
    {
        if (initGame.alive==true)
        {
            if (loaded == false)
            {
                escudoEnergy.value += 5f * Time.deltaTime;
                if (escudoEnergy.value >= 100f)
                {
                    loaded = true;
                }
            }



            if (Input.GetButtonDown("Escudo") && loaded == true)
            {
                
                escudoEnergy.value = 0;
                loaded = false;
                shield = true;
                Escudo();
                
            }

           


        }
       
            
        

    }

    public void Escudo()
    {
        Invoke("PararEscudo", 5f);
    }

    void PararEscudo()
    {
        shield = false;
       
    }
}

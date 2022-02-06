using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyField : MonoBehaviour
{
    InitGame initGame;

    [SerializeField] Slider escudoEnergy;

    //carga y descarga escudo para su uso
    public bool loaded;

    //variable para activar y desactivar escudo
    public bool shield;

    // Carga extra de escudo por power up
    public bool PowerUpBoost;

    //Particulas escudo
    public GameObject shieldParticle;
    [SerializeField] Transform PartPos;


    // Start is called before the first frame update
    void Start()
    {

        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();
        escudoEnergy.value = 0f;
        loaded = false;
        shield = false;
        PowerUpBoost = false;
        
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
            

            if (loaded == false && PowerUpBoost == false)
            {
                escudoEnergy.value += 5f * Time.deltaTime;
                
                if (escudoEnergy.value >= 100f)
                {
                    loaded = true;
                }
    
            }

            else if (loaded == false && PowerUpBoost == true)
            {
                escudoEnergy.value += 20f; 
                PowerUpBoost = false;
                
            }

            

            if (Input.GetButtonDown("Escudo") && loaded == true)
            {
                //Particulas escudo instanciado
                Vector3 newPosShield = new Vector3(PartPos.position.x, PartPos.position.y, PartPos.position.z);
                GameObject shieldClone = Instantiate(shieldParticle, newPosShield, Quaternion.identity) as GameObject;
                Destroy(shieldClone, 5);
                
                //Carga y disminucion score
                initGame.restaScore = true;
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

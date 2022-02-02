using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    InitGame initGame;
    EnergyField energyField;
    
    

    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGameObj").GetComponent<InitGame>();
        energyField = GameObject.Find("SlEnergy").GetComponent<EnergyField>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            
            Destroy(gameObject);
            
        }
        
        
    }

   
}

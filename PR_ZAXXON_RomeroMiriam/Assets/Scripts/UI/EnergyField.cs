using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyField : MonoBehaviour
{
    [SerializeField] Slider escudoEnergy;

    bool loaded;

    // Start is called before the first frame update
    void Start()
    {
        escudoEnergy.value = 0f;
        loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(loaded==false)
        {
            escudoEnergy.value += 5f * Time.deltaTime;
            if (escudoEnergy.value >= 100f)
            {
                loaded = true;
            }
        }

        if (Input.GetKeyDown("space") && loaded==true)
        {
            escudoEnergy.value = 0;
            loaded = false;
        }
        
    }
}

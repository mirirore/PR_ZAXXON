using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    float PlanetSpeedMove = 1f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * PlanetSpeedMove);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    [SerializeField] GameObject ladrillo;
    [SerializeField] Transform InitPos;

    float separacion =2f;
    
    // Start is called before the first frame update
    void Start()
    {

        Vector3 newPos =InitPos.position; //Se escribe.position en InitPos porque es una variable tipo transform
        Vector3 despl = new Vector3 (separacion,0f,0f);

        for (int n=0; n<10;n++)
        {

            Instantiate(ladrillo, newPos,Quaternion.identity); //Primera vuelta en la cual new pos = init pos
            newPos = newPos + despl; //Segunda vuelta
        }

    }

    
}

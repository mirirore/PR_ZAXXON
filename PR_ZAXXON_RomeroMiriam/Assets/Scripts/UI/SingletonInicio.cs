using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonInicio : MonoBehaviour
{
    
    private void Start()
    {
        if (GameManager.MusicaInicio == false)
        {
            DontDestroyOnLoad(gameObject);
            GameManager.MusicaInicio = true;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        if (GameManager.MusicaInicio ==false)
        {
            Destroy(gameObject);
            
        }
    }
}

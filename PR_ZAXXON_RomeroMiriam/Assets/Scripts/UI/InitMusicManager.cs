using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMusicManager : MonoBehaviour
{

    private static InitMusicManager instance;

   //Start is called before the first frame update
    void Start()
    {
        
    }

   


    private void Awake()
    {
        
        if (instance == null)
        {
            
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            
            Destroy(this);
            
        }
    }



           
     

}

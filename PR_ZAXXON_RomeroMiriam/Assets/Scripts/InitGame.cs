using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
   public int levelGame;
   public float speed;
    public float rotationspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpeedLevel");


    }

   IEnumerator SpeedLevel()
    {
      while(true)
        {
            yield return new WaitForSeconds(30f);

            speed = speed + 10;
            levelGame++;

            if (levelGame == 8)
            {
                StopCoroutine ("SpeedLevel");
            }

        }
    }
   
    
}

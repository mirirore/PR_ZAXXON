using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{
    public int levelGame;
    public float speed = 40f;

   

    /*PUNTUACION VARIABLES
    static float score;
    [SerializeField] float MaxSpeed;
    public bool alive;
    [SerializeField] Text scoreText;
    */

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpeedLevel");

        
        /*SCORE
        score = 0;
        MaxSpeed = 100f;
        alive = true;
        */
        
    }


    /*UPDATE PARA VER TIEMPO QUE HA PASADO PARA LA SCORE
    private void Update()
    {
        if (speed < MaxSpeed && alive == true)
        {
            speed += 0.001f;
        }
        float tiempo = Time.time;
        print(Mathf.Round(tiempo));

        score = Mathf.Round(tiempo) * speed;
       scoreText.text = Mathf.Round(score) + "mts.";
    }
    */


    IEnumerator SpeedLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);

            speed = speed + 5;
            levelGame++;

            if (levelGame == 7)
            {
                StopCoroutine("SpeedLevel");
            }

        }
    }

    
   
    
}

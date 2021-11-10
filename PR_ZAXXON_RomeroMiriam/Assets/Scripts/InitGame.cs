using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{
    public int levelGame;
    public float speed = 40f;
    public bool alive;

    //GAMEOVER
    GameObject Derrota;
    Canvas GameOver;
    [SerializeField] Button BotonGeneral;


    //UI Score
    static float score;
    
    [SerializeField] Text ScoreText;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpeedLevel");


        //SCORE
        
        ScoreText.text = "PUNTOS " + (Mathf.Round(score));

        //Game Over
        Derrota = GameObject.Find("GameOver");
        GameOver = Derrota.GetComponent<Canvas>();
        GameOver.enabled = false;
        
    }


    //UPDATE PARA VER TIEMPO QUE HA PASADO PARA LA SCORE
    private void Update()
    {

       float tiempo = Time.timeSinceLevelLoad;
       score = Mathf.Round(tiempo) * speed;
       ScoreText.text = "PUNTOS "+ Mathf.Round(score) ;
    }
    

    
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


    /*public void Escudo()
    {
        Invoke("PararEscudo", 5f);
    }

        void PararEscudo()
    {

    }
    */

   public void Morir()
    {
        alive = false;
        speed = 0f;
        InstObs instObs = GameObject.Find("InstancObst").GetComponent<InstObs>();
        instObs.SendMessage("PararInstancia");
        //GameObject.Find("Nave").SetActive(false);

        //Game Over
        GameOver.enabled = true;
        BotonGeneral.Select();

    }

    
}

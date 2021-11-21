using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] Text ScoreText;
    static float score;

    //UI nivel
    [SerializeField] Text LevelText;
    




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpeedLevel");

        StartCoroutine("ContadorScore");


        alive = true;
        
       
        //Game Over
        Derrota = GameObject.Find("GameOver");
        GameOver = Derrota.GetComponent<Canvas>();
        GameOver.enabled = false;
        
    }


 
    private void Update()
    {
        HudNivel(); 

    }
    
    IEnumerator ContadorScore()
    {
        //Score
        while(true)
        {
            float tiempo = Time.time;
            score = Mathf.Round(tiempo);
            ScoreText.text = "PUNTOS " + Mathf.Round(score);
            yield return new WaitForSeconds(0.1f);
        }
       
    }

    public void HudNivel()
    {
 
        //Nivel
        if (levelGame==0)
        {
            LevelText.text = "00 MERCURIO";
        }
        if (levelGame == 1)
        {
            LevelText.text = "01 VENUS";
        }
        if (levelGame == 2)
        {
            LevelText.text = "02 MARTE";
        }
        if (levelGame == 3)
        {
            LevelText.text = "03 JÚPITER";
        }
        if (levelGame == 4)
        {
            LevelText.text = "04 SATURNO";
        }
        if (levelGame == 5)
        {
            LevelText.text = "05 URANO";
        }
        if (levelGame == 6)
        {
            LevelText.text = "06 NEPTUNO";
        }
    }

    //Aumento velocidad y cambio de nivel
    IEnumerator SpeedLevel()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);

            speed = speed + 5;
            levelGame++;

            //Fin del juego
            if (levelGame == 7)
            {
                SceneManager.LoadScene(5);
            }

        }
    }

    //Score 

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
        StopCoroutine("ContadorScore");

        //Mandar Score a pantalla HIGHSCORE
        if (score > GameManager.HighScore)
        {
            GameManager.ThirdScore = GameManager.SecondScore;
            GameManager.SecondScore = GameManager.HighScore;
            GameManager.HighScore = score;
        }

        else if (score < GameManager.HighScore && score > GameManager.SecondScore)
        {
            GameManager.ThirdScore = GameManager.SecondScore;
            GameManager.SecondScore = score;
        }

        else if (score < GameManager.SecondScore && score > GameManager.ThirdScore)
        {
            GameManager.ThirdScore = score;
        }
        GameObject.Find("Nave").SetActive(false);

        //Game Over
        GameOver.enabled = true;
        BotonGeneral.Select();
    }
   
    
}

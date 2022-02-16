using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitGame : MonoBehaviour
{
    public int levelGame;
    public float speed = 30f;
    public bool alive;

   
    //Llamar escudo y restaScore
    EnergyField energyField;
    public bool restaScore;
    float castigo = 0;
    
    //GAMEOVER
    GameObject Derrota;
    Canvas GameOver;
    [SerializeField] Button BotonGeneral;
    

    /*----Audio----*/
    AudioSource AudioSourceNave;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip impacto;

    /*------UI------*/
    //UI Score
    [SerializeField] Text ScoreText;
    public static float score;

    //UI nivel
    [SerializeField] Text LevelText;

    //UI Vidas
    [SerializeField] Image vidas;
    [SerializeField] Sprite[] livesArray;
    int lives;
    int spritePos = 0;

    /*------Particulas explosion-----*/
    public GameObject explosParticle;
    [SerializeField] Transform navePos;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpeedLevel");

        StartCoroutine("ContadorScore");

        //Vidas
        lives = 3;
        vidas.sprite = livesArray[spritePos];

        //Estado incial
        alive = true;

        //RestaScore
        restaScore = false;
        
       
        //Game Over
        Derrota = GameObject.Find("GameOver");
        GameOver = Derrota.GetComponent<Canvas>();
        GameOver.enabled = false;

       
        energyField = GameObject.Find("SlEnergy").GetComponent<EnergyField>();

        AudioSourceNave = GameObject.Find("Nave").GetComponent<AudioSource>();

        
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
            float tiempo = ((Time.timeSinceLevelLoad * speed) - castigo);
            score = Mathf.Round(tiempo);
            ScoreText.text = "PUNTOS: " + Mathf.Round(score);
            
           if (restaScore == true)
            {
            
                castigo = castigo + 200f;
                restaScore = false;
            }


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

                SceneManager.LoadScene(5);
            }

        }
    }

    

    
    public void Chocar()
    {
        if(energyField.shield==false)
        {

            //sonido impacto
            AudioSourceNave.PlayOneShot(impacto, 0.1f);

            //Quita vidas y desactivar pantalla game over
            lives--;
            spritePos++;
            vidas.sprite = livesArray[spritePos];
            GameOver.enabled = false;

            if (lives == 0)
            {
                Morir();

            }
            
        }
        
    }
       

        public void Morir()
    {

        //sonido explosion
        AudioSourceNave.Stop();
        AudioSourceNave.PlayOneShot(explosion,0.5f);
        

        alive = false;
        speed = 0f;
        InstObs instObs = GameObject.Find("InstancObst").GetComponent<InstObs>();
        Invoke("MostrarGameOver", 3f);
        GameObject.Find("nave_entera1").SetActive(false);

        

        //Instancia explosion
        Vector3 newPosExplosion = new Vector3(navePos.position.x, navePos.position.y, navePos.position.z);
        GameObject ExplosionClone = Instantiate(explosParticle, newPosExplosion, Quaternion.identity) as GameObject;
        Destroy(ExplosionClone, 2);

        //Parar corrutinas
        instObs.SendMessage("PararInstancia");
        StopCoroutine("ContadorScore");
        StopCoroutine("SpeedLevel");

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
        
    }

    void MostrarGameOver()
    {
        GameOver.enabled = true;
        BotonGeneral.Select();
    }

}

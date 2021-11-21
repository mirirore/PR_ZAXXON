using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{

    public Text HighScore;
    public Text SecondScore;
    public Text ThirdScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighScore.text = Mathf.Round(GameManager.HighScore).ToString() + " ptos";
        SecondScore.text = Mathf.Round(GameManager.SecondScore).ToString() + " ptos";
        ThirdScore.text = Mathf.Round(GameManager.ThirdScore).ToString() + " ptos";
    }
}

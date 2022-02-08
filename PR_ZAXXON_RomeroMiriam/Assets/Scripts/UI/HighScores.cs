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
        HighScore.text = "1. " + Mathf.Round(GameManager.HighScore).ToString();
        SecondScore.text = "2. " + Mathf.Round(GameManager.SecondScore).ToString();
        ThirdScore.text = "3. " + Mathf.Round(GameManager.ThirdScore).ToString();
    }
}

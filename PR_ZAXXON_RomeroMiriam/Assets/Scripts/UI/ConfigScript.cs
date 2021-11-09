using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigScript : MonoBehaviour
{

    [SerializeField] Slider volumenSL;
    [SerializeField] Text volumenText;
    float volumen;
    
    // Start is called before the first frame update
    void Start()
    {
        volumenSL.value = GameManager.VolumenMusica;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void CambiarVolumen()
    {
        volumen = volumenSL.value;
        volumenText.text = "Volumen" + volumen;
    }
    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
    }
}

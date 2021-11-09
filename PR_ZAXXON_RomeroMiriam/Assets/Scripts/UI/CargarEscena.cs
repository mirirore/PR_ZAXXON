using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    
    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
    }

    public void Juego()
    {
        SceneManager.LoadScene(1);
    }

    public void Configuracion()
    {
        SceneManager.LoadScene(2);
    }

    public void Puntos()
    {
        SceneManager.LoadScene(3);
    }

    public void ComoJugar()
    {
        SceneManager.LoadScene(4);
    }

    
   
}

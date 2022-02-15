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
        GameManager.MusicaInicio = false;
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

    public void JuegoCompletado()
    {
        SceneManager.LoadScene(5);
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }
   
}

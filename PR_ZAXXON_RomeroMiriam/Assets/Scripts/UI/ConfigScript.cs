using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ConfigScript : MonoBehaviour
{
    //VARIABLES SLIDER MUSICA Y EFECTOS

   // [SerializeField] Slider MusicVolume;

    //float volumen;

   // [SerializeField] Slider FxVolume;

    //float volumenfx;

    

    public AudioMixer mixer;


    // Start is called before the first frame update
    void Start()
    {
        

        /*volMusicaSL.value = GameManager.VolumenMusica;
        volEfectosSL.value = GameManager.VolumenEfectos;*/
       

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusic(float soundLevelMusic)
    {
        mixer.SetFloat("ExposedMusica", soundLevelMusic);
    }

    /*public void SetFX(float soundLevelFX)
    {
        mixer.SetFloat("ExposedEfectos", soundLevelFX);
    }*/
    

    /*public void CambiarVolumen()
    {
        volumen = volMusicaSL.value;
        volumenfx = volEfectosSL.value;
        
    }*/
    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
    }
}

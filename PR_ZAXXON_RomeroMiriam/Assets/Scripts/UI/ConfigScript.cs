using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ConfigScript : MonoBehaviour
{
    //VARIABLES SLIDER MUSICA Y EFECTOS
    public Slider bgmSlider, sfxSlider;
    public AudioMixer mixer;

    


    // Start is called before the first frame update
    void Start()
    {

        bgmSlider.onValueChanged.AddListener(delegate {SetSound("BGMVolume", bgmSlider.value); });
        sfxSlider.onValueChanged.AddListener(delegate {SetSound("SFXVolume", sfxSlider.value); });
       
    }

    public void SetSound(string param, float soundLevel)
    {
        mixer.SetFloat(param, soundLevel);
    }

    
    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
    }
}

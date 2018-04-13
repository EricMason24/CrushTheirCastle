using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour {
    Slider volumeSlider;
    AudioSource adio;
    public float gameVolume = 1;
    // Use this for initialization
    void Start () {
        adio = GetComponent<AudioSource>();
        adio.volume = gameVolume;
        adio.Play();
    }
	
    public void changeVolume(float volume)
    {
        volumeSlider = GameObject.Find("Volume Slider").GetComponent<Slider>();
        if (volume < 0)
            adio.volume = volumeSlider.value;
        else
            adio.volume = volume;

        volumeSlider.value = adio.volume;
        gameVolume = adio.volume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour {

    [Header("UI")]
    public Canvas p1Canvas;
    public Canvas p2Canvas;
    public Canvas pauseCanvas;
    public Slider volumeSlider;

    MenuManager menu;
    VolumeHolder vHolder;

    private bool p1Turn = true;

	// Use this for initialization
	void Start () {
        menu = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        vHolder = GameObject.Find("KeeperOfVolume").GetComponent<VolumeHolder>();
        volumeSlider.value = menu.GetComponent<AudioSource>().volume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToGame() {
        if (p1Turn) {
            p1Canvas.gameObject.SetActive(true);
            pauseCanvas.gameObject.SetActive(false);
        } else {
            p2Canvas.gameObject.SetActive(true);
            pauseCanvas.gameObject.SetActive(false);
        }
    }

	public void pause()
    {
        if (p1Canvas.gameObject.activeSelf)
            p1Turn = true;
        else
            p1Turn = false;
        p1Canvas.gameObject.SetActive(false);
        p2Canvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
    }

    public void changeVolume() {
        menu.changeVolume(volumeSlider.value);
    }

    public void exit() {
        vHolder.updateHolder();
        Destroy(GameObject.Find("MenuManager"));
        SceneManager.LoadSceneAsync("Main Menu");
    }
}

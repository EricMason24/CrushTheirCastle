using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Canvas startCanvas;
    public Canvas sizeCanvas;

    public int sceneSize = 1;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        startCanvas.gameObject.SetActive(true);
        sizeCanvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame() {
        switchCanvas();
    }

    public void switchToGame(int size) {
        sceneSize = size;
        SceneManager.LoadSceneAsync(sceneName: "TurretScene");
        //SceneManager.UnloadSceneAsync(sceneName: "Main Menu");
    }

    public void switchToMenu() {
        SceneManager.LoadSceneAsync(sceneName: "Main Menu");
        //SceneManager.UnloadSceneAsync(sceneName: "TurretScene");
    }

    void switchCanvas() {
        if (startCanvas.gameObject.active)
            startCanvas.gameObject.SetActive(false);
        else
            startCanvas.gameObject.SetActive(true);
        
        if (sizeCanvas.gameObject.active)
            sizeCanvas.gameObject.SetActive(false);
        else
            sizeCanvas.gameObject.SetActive(true);
    }
}

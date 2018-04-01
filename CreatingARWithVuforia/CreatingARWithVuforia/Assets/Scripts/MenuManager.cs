using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Canvas startCanvas;
    public Canvas sizeCanvas;
    public Canvas treasureCanvasP1;
    public Canvas treasureCanvasP2;

    public int sceneSize = 1;
    public float p1Xpos;
    public float p2Xpos;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        startCanvas.gameObject.SetActive(true);
        sizeCanvas.gameObject.SetActive(false);
	}

    public void startGame() {
        switchCanvas();
    }

    public void switchToGame(int size) {
        sceneSize = size;
        switchToTreasureCanvas();
        //SceneManager.LoadSceneAsync(sceneName: "TurretScene");
        //SceneManager.UnloadSceneAsync(sceneName: "Main Menu");
    }

    public void chooseTreasureLoc1(float xpos)
    {
        p1Xpos = xpos;
        switchToTreasureCanvas();
    }

    public void chooseTreasureLoc2(float xpos)
    {
        p2Xpos = xpos;
        switchToTreasureCanvas();
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

    void switchToTreasureCanvas()
    {
        if (treasureCanvasP1.gameObject.active)
        {
            treasureCanvasP1.gameObject.SetActive(false);
            treasureCanvasP2.gameObject.SetActive(true);
        }
        else if(treasureCanvasP2.gameObject.active)
        {
            treasureCanvasP2.gameObject.SetActive(false);
            SceneManager.LoadSceneAsync(sceneName: "TurretScene");
        }
        else
        {
            sizeCanvas.gameObject.SetActive(false);
            treasureCanvasP1.gameObject.SetActive(true);
        }
    }
}

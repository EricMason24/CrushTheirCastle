using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [Header ("Canvas References")]
    public Canvas startCanvas;
    public Canvas sizeCanvas;
    public Canvas treasureCanvasP1;
    public Canvas treasureCanvasP2;

    [Header ("Setup Variables")]
    public int sceneSize = 1;
    public float p1Xpos;
    public float p2Xpos;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        startCanvas.gameObject.SetActive(true);
        sizeCanvas.gameObject.SetActive(false);
        treasureCanvasP1.gameObject.SetActive(false);
        treasureCanvasP2.gameObject.SetActive(false);
	}

    public void startGame() {
        switchCanvas();
    }

    public void switchToGame(int size) {
        sceneSize = size;
        switchToTreasureCanvas();
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

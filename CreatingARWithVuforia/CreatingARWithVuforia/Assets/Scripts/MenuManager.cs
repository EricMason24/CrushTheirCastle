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
    public Canvas tutorialCanvas1;
    public Canvas tutorialCanvas2;
    //public Canvas tutorialCanvas3;

    [Header ("Setup Variables")]
    public int sceneSize = 1;
    public int p1pos;
    public int p2pos;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        startCanvas.gameObject.SetActive(true);
        sizeCanvas.gameObject.SetActive(false);
        treasureCanvasP1.gameObject.SetActive(false);
        treasureCanvasP2.gameObject.SetActive(false);
        tutorialCanvas1.gameObject.SetActive(false);
        tutorialCanvas2.gameObject.SetActive(false);
        //tutorialCanvas3.gameObject.SetActive(false);
    }

    public void startGame() {
        switchCanvas();
    }

    public void switchToGame(int size) {
        sceneSize = size;
        switchToTreasureCanvas();
    }

   

    public void chooseTreasureLoc1(int loc)
    {
        p1pos = loc;
        switchToTreasureCanvas();
    }

    public void chooseTreasureLoc2(int loc)
    {
        p2pos = loc;
        switchToTreasureCanvas();
    }

    public void switchToMenu() {
        SceneManager.LoadSceneAsync(sceneName: "Main Menu");
    }

    void switchCanvas() {
        if (startCanvas.gameObject.activeSelf)
            startCanvas.gameObject.SetActive(false);
        else
            startCanvas.gameObject.SetActive(true);
        
        if (sizeCanvas.gameObject.activeSelf)
            sizeCanvas.gameObject.SetActive(false);
        else
            sizeCanvas.gameObject.SetActive(true);
    }

    void switchToTreasureCanvas()
    {
        if (treasureCanvasP1.gameObject.activeSelf)
        {
            treasureCanvasP1.gameObject.SetActive(false);
            treasureCanvasP2.gameObject.SetActive(true);
        }
        else if(treasureCanvasP2.gameObject.activeSelf)
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

    //tutorial transitions
    public void tutorialBegin()
    {
        startCanvas.gameObject.SetActive(false);
        tutorialCanvas1.gameObject.SetActive(true);
    }

    public void switchToTutorialCanvas(string canvas)
    {
        switch (canvas)
        {
            case "TutorialCanvas2":
                tutorialCanvas1.gameObject.SetActive(false);
                tutorialCanvas2.gameObject.SetActive(true);
                //SceneManager.LoadSceneAsync(sceneName: "TutorialScene1");
                break;
            case "TutorialCanvas3":
                tutorialCanvas2.gameObject.SetActive(false);
                //tutorialCanvas3.gameObject.SetActive(true);
                SceneManager.LoadSceneAsync(sceneName: "TutorialScene2");
                break;

            default:
                tutorialCanvas2.gameObject.SetActive(false);
                tutorialCanvas1.gameObject.SetActive(true);
                break;

        }
    }
}


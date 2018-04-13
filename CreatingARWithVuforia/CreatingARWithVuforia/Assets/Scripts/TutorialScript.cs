using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

    [Header("Canvas + Camera")]
    public Canvas Canvas1;
    public Canvas Canvas2;
    public Canvas Canvas3;
    public Canvas Canvas4;
    public Camera mainCam;

    VolumeHolder vHolder;



    [Header("Objects to destroy")]
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject treasure;

    // Use this for initialization
    void Start() {
        vHolder = GameObject.Find("KeeperOfVolume").GetComponent<VolumeHolder>();
        Canvas1.gameObject.SetActive(true);
        Canvas2.gameObject.SetActive(false);
        Canvas3.gameObject.SetActive(false);
        Canvas4.gameObject.SetActive(false);
    }

    public void switchCanvas(int canvas)
    {
        switch (canvas)
        {
            case 2:
                Canvas1.gameObject.SetActive(false);
                Canvas2.gameObject.SetActive(true);
                mainCam.gameObject.transform.position += new Vector3((float)6.944, (float)-4.781, (float)-1.85);
                mainCam.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 3:
                Canvas2.gameObject.SetActive(false);
                Canvas3.gameObject.SetActive(true);
                mainCam.gameObject.transform.position += new Vector3((float).018, (float)2.047, (float)2.733);
                mainCam.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
                Destroy(wall1);
                Destroy(wall2);
                Destroy(wall3);
                Destroy(wall4);
                break;
            case 4:
                Canvas3.gameObject.SetActive(false);
                Canvas4.gameObject.SetActive(true);
                Destroy(treasure);
                break;
            default:
                Canvas1.gameObject.SetActive(true);
                Canvas2.gameObject.SetActive(false);
                break;
        }
    }

    public void returnToMenu()
    {
        vHolder.updateHolder();
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        Destroy(GameObject.Find("MenuManager"));
        SceneManager.LoadScene("Main Menu");
        
    }
}

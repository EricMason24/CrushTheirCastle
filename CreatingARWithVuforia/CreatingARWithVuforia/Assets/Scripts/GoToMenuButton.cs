using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMenuButton : MonoBehaviour {

    canvasManager manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Ground Plane Stage").GetComponent<canvasManager>();
        GetComponent<Button>().onClick.AddListener(manager.exit);
	}
}

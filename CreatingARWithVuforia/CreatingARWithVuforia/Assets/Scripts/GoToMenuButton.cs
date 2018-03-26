using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMenuButton : MonoBehaviour {

    MenuManager manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        GetComponent<Button>().onClick.AddListener(manager.switchToMenu);
	}
}

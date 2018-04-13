using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeHolder : MonoBehaviour {

    public float volume;
    MenuManager menu = null;
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start () {
        while(menu == null)
        {
            menu = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        }
       
    }
	
	public void updateHolder()
    {
        if(menu != null)
        {
            volume = menu.GetComponent<AudioSource>().volume;
        }
        else
        {
            menu = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        }
        
    }
}

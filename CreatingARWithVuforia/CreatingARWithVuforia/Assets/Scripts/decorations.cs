using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorations : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(0, Random.rotation.eulerAngles.y, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
	public float timeAfterHit = 0f;

	public Text victoryText;
	public Canvas Canvas1;
	public Canvas Canvas2;
	public Canvas vicCanvas;

	public void Hit()
	{
		if (gameObject.CompareTag ("p1treasure")) {
			victoryText.text = "Player 2 Wins!";
			Canvas1.gameObject.SetActive (false);
			Canvas2.gameObject.SetActive (false);
			vicCanvas.gameObject.SetActive (true);
		} else if(gameObject.CompareTag("p2treasure")){
			victoryText.text = "Player 1 Wins!";
			Canvas1.gameObject.SetActive (false);
			Canvas2.gameObject.SetActive (false);
			vicCanvas.gameObject.SetActive (true);
		}
			
		Destroy(gameObject, timeAfterHit);
	}
}

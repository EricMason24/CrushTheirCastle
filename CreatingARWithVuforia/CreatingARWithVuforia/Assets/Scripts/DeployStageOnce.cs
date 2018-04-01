using System;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeployStageOnce : MonoBehaviour {

    [Header("Game Board Objects")]
	public GameObject AnchorStage;
    public GameObject PlayStage;
    public GameObject p1Treasure;
    public GameObject p2Treasure;

	private PositionalDeviceTracker _deviceTracker;
	private GameObject _previousAnchor;
	private int sanity;

    MenuManager manager;

    [Header("Canvas Objects")]
    public Canvas Canvas1;
    public Canvas Canvas2;
	public Canvas vicCanvas;


    public void Start ()
	{
		if (AnchorStage == null)
		{
			Debug.Log("AnchorStage must be specified");
			return;
		}

		AnchorStage.SetActive(false);
		sanity = 0;
	}

	public void Awake()
	{
		VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        manager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        Debug.Log(manager.sceneSize);
        Debug.Log(manager.p1Xpos);
        Debug.Log(manager.p2Xpos);
    }

	public void OnDestroy()
	{
		VuforiaARController.Instance.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
	}

	private void OnVuforiaStarted()
	{
		_deviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        Canvas1.gameObject.SetActive(true);
		Canvas2.gameObject.SetActive (false);
		vicCanvas.gameObject.SetActive (false);
	}

	public void OnInteractiveHitTest(HitTestResult result)
	{
		if (result == null || AnchorStage == null)
		{
			Debug.LogWarning("Hit test is invalid or AnchorStage not set");
			return;
		}

		var anchor = _deviceTracker.CreatePlaneAnchor(Guid.NewGuid().ToString(), result);

		if (anchor != null && sanity == 0)
		{
			AnchorStage.transform.parent = anchor.transform;
			AnchorStage.transform.localPosition = Vector3.zero;
            PlayStage.transform.localScale = new Vector3(manager.sceneSize, manager.sceneSize, manager.sceneSize);
			AnchorStage.transform.localRotation = Quaternion.identity;
			AnchorStage.SetActive(true);
            switch(manager.sceneSize) {
                case 1:
                    Time.timeScale = 1.0f;
                    break;
                case 2:
                    Time.timeScale = 1.2f;
                    break;
                case 3:
                    Time.timeScale = 1.4f;
                    break;
                default:
                    Time.timeScale = 1.0f;
                    break;
            }
            p1Treasure.transform.position = new Vector3(manager.p1Xpos, 0, (float)-0.775);
            p2Treasure.transform.position = new Vector3(manager.p2Xpos, 0, (float)-0.775);
        }

		sanity++;
	}
}
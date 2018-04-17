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
    public Transform p1TPosRight;
    public Transform p1TPosLeft;
    public Transform p2TPosRight;
    public Transform p2TPosLeft;

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

        //Debug.Log(manager.sceneSize);
        //Debug.Log(manager.p1Xpos);
        //Debug.Log(manager.p2Xpos);
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
            PlayStage.transform.localScale = new Vector3(PlayStage.transform.localScale.x * manager.sceneSize, PlayStage.transform.localScale.y * manager.sceneSize, PlayStage.transform.localScale.z * manager.sceneSize);
			AnchorStage.transform.localRotation = Quaternion.identity;
			AnchorStage.SetActive(true);
            switch(manager.sceneSize) {
                case 1:
                    Time.timeScale = 1.0f;
                    break;
                //case 2:

                //    Time.timeScale = 1.2f;
                //    break;
                //case 3:
                    //Time.timeScale = 1.4f;
                    //break;
                default:
                    Time.timeScale = 1.0f;
                    break;
            }
            if (manager.p1pos == 1)
                p1Treasure.transform.position += p1TPosLeft.position - p1Treasure.transform.position;
            else if (manager.p1pos == 2)
                p1Treasure.transform.position += p1TPosRight.position - p1Treasure.transform.position;
            if (manager.p2pos == 1)
                p2Treasure.transform.position += p2TPosLeft.position - p2Treasure.transform.position;
            else if (manager.p2pos == 2)
                p2Treasure.transform.position += p2TPosRight.position - p2Treasure.transform.position;
        }

		sanity++;
	}
}
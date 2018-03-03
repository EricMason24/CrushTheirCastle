﻿using System;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeployStageOnce : MonoBehaviour {

	public GameObject AnchorStage;
	private PositionalDeviceTracker _deviceTracker;
	private GameObject _previousAnchor;
	private int sanity;

    [Header("Canvas Ojects")]
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
	}

	public void OnDestroy()
	{
		VuforiaARController.Instance.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
	}

	private void OnVuforiaStarted()
	{
		_deviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
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
			AnchorStage.transform.localRotation = Quaternion.identity;
			AnchorStage.SetActive(true);
		}

		sanity++;
	}
}
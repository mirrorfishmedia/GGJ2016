﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMan : MonoBehaviour {

	public CanvasAlphaLerper[] canvasGroups;

	int playersAdded = 0;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FadeOutText()
	{
		canvasGroups [playersAdded].target = 0;
		playersAdded++;
		Debug.Log ("playersAdded: " + playersAdded);
	}

	public void FadeInStart()
	{
		canvasGroups [2].target = 1;
	}

	public void FadeOutStart()
	{
		canvasGroups [2].target = 0;
	}

	public void FadeInTimer()
	{
		canvasGroups [3].target = 1;
	}
}

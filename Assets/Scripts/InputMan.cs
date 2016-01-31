using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using System;

/// <summary>
/// Input joiner to manage all the "press A to join"
/// </summary>
public class InputMan : MonoBehaviour {

	public bool gameStarted = false;

	public event EventHandler OnPlayerJoined;
	public event EventHandler OnStartAvailable;
	public event EventHandler OnStartPressed;

	public InputDevice[] devices{get{return joinedDevices.ToArray();}}
	private List<InputDevice> joinedDevices;

	int maxPlayers = 4;


	void Awake(){
		joinedDevices = new List<InputDevice>();
	}


	// Update is called once per frame
	void Update () {

		InputDevice dev = InputManager.ActiveDevice;

		//join player
		if (dev != null && dev.Action1.WasPressed){
			if (!joinedDevices.Contains(dev) && joinedDevices.Count < maxPlayers){
				joinedDevices.Add(dev);
				OnPlayerJoined.Raise(this);
				Debug.Log("PLAYER JOINED " + dev.Name);
				if (joinedDevices.Count >= 2){
					OnStartAvailable.Raise(this);
				}
			}
		}

		if (dev != null && dev.MenuWasPressed && joinedDevices.Count >= 2 && !gameStarted){
			gameStarted = true;
			Debug.Log("CALL START PRESSED!");
			OnStartPressed.Raise(this);
		}
		//press start to finish
	}

}

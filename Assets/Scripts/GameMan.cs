using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine.UI;

public class GameMan : MonoBehaviour {

	public EnvironmentMan environment;

	public DefendingPlayer defendingPlayer;

	public MonkActions monkCtrlActions;
	public List<AttackerActions> attackerActions;

	public Transform camSpawnPos;

	public enum resourceColor
	{
		fire, water, skull, leaf
	}

	public resourceColor neededColor = resourceColor.fire;
	private int currentResourceTotal = 0;
	private int maxResources = 5;
	private int colorsScored = 0;
	private int colorGoal = 4;

	private InputMan joiner;


	[HideInInspector] public GameObject spawnedCam;
	private CameraControl camControlScript;



	void Awake()
	{
		SetupCamera ();
		joiner = GetComponent<InputMan>();
		joiner.OnStartPressed += (sender, e) => {StartGame();};
	}


	void Reset(){
		Application.LoadLevel (Application.loadedLevel);
	}


	void Update(){
	}

	// Use this for initialization
	void StartGame () {
		Debug.Log("START GAME!");
		SetupReticule ();
		SetupDefender();
		SetupAttackers ();
	}

	void SetupDefender(){
		defendingPlayer.Init(joiner.devices[0], environment.shrineDestinations);
	}



	void SetupCamera(){
		Debug.Log("HEY");
		spawnedCam = PrefabManager.Instantiate ("CameraRig", Vector3.zero, camSpawnPos.rotation) as GameObject;
		camControlScript = spawnedCam.GetComponent<CameraControl> ();

	}



	void SetupReticule()
	{
	}

	void SetupAttackers()
	{
		attackerActions = new List<AttackerActions>();

		var devices = joiner.devices;
		for(int i = 1; i < devices.Length; i++){
			var attacker = PrefabManager.Instantiate ("AttackingPlayer", Vector3.zero).GetComponent<AttackingPlayer>();
			attacker.Init(devices[i]);
		}
	}

	public void AddResource(resourceColor collectedResource)

	{
		Debug.Log ("in addResource");
		if (collectedResource == neededColor) 
		{
			Debug.Log ("got needed color");

			currentResourceTotal++;
			Debug.Log ("currentResource count " + currentResourceTotal);
			if (currentResourceTotal >= maxResources)
			{
				currentResourceTotal = 0;
				Debug.Log ("Reset resources to : " + currentResourceTotal);
				ColorScored();
			}
		}
	}

	void ColorScored()
	{
		Debug.Log ("in color scored");
		colorsScored++;
		Debug.Log ("colors scored " + colorsScored);
		if (colorsScored >= colorGoal) 
		{
			DefenderWins();
		}
	}

	void DefenderWins()
	{
		Debug.Log ("Defender wins the round!");
	}

	void AttackerWins()
	{
		Debug.Log ("Attacker wins the round!");
	}



}

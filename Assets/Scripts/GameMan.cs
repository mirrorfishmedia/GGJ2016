using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine.UI;

public class GameMan : MonoBehaviour {

	public Environmenter environment;

	public DefendingPlayer defendingPlayer;

	public GameObject camPrefab;
	public GameObject turretTargetPf;

	public MonkActions monkCtrlActions;
	public List<AttackerActions> attackerActions;

	public int numAttackers = 1;
	public InputDevice inputDevice0;
	public InputDevice inputDevice1;

	public GameObject attackingPlayerPf;
	public Transform[] spawnPoints;
	public Transform camSpawnPos;
	public Transform reticuleSpawnPos;
	public TurretShoot turretScript;
	public Image damageImage1;
	public Slider healthSlider1;
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
		spawnedCam = Instantiate (camPrefab, Vector3.zero, camSpawnPos.rotation) as GameObject;
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
			var attacker = PrefabManager.Instantiate ("AttackingPlayer", spawnPoints [i].position).GetComponent<AttackingPlayer>();
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

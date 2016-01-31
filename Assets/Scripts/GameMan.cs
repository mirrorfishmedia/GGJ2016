using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.UI;

public class GameMan : MonoBehaviour {

	public Transform[] sceneDestinations;

	public SpawnMonks monkSpawner;

	public GameObject camPrefab;
	public GameObject turretTargetPf;

	public MonkActions monkCtrlActions;
	public AttackerActions attackerActions1;
	public AttackerActions attackerActions2;
	public AttackerActions attackerActions3;

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
		red, blue, yellow, green
	}

	public resourceColor neededColor = resourceColor.red;
	private int currentResourceTotal = 0;
	private int maxResources = 5;


	[HideInInspector] public GameObject spawnedCam;
	private CameraControl camControlScript;



	void Awake()
	{
		inputDevice0 = InputManager.Devices [0];
		inputDevice1 = InputManager.Devices [1];

	}


	void Reset()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	void Update()
	{
		if (Input.GetButton ("Jump"))
			Reset ();
	}
	// Use this for initialization
	void Start () 
	{
		SetupCamera ();
		SetupReticule ();
		SetupAttackers ();
		monkSpawner.spawnerDestinations = sceneDestinations;
		SetUpDefenderActions ();
		SetupAttackerActions1 ();

	}

	void SetUpDefenderActions()
	{
		//InputDevice device = InputManager.ActiveDevice;
		//InputControl control = device.GetControl( InputControlType.Action1 )

		monkCtrlActions = new MonkActions();
		monkCtrlActions.Device = inputDevice0;


		monkCtrlActions.spawn0.AddDefaultBinding (InputControlType.Action1);
		monkCtrlActions.spawn1.AddDefaultBinding (InputControlType.Action2);
		monkCtrlActions.spawn2.AddDefaultBinding (InputControlType.Action3);
		monkCtrlActions.spawn3.AddDefaultBinding (InputControlType.Action4);
		monkCtrlActions.fireTurret.AddDefaultBinding (InputControlType.RightTrigger);

		monkCtrlActions.moveUnitLeft.AddDefaultBinding (InputControlType.LeftStickLeft);
		monkCtrlActions.moveUnitRight.AddDefaultBinding (InputControlType.LeftStickRight);
		monkCtrlActions.moveUnitUp.AddDefaultBinding (InputControlType.LeftStickUp);
		monkCtrlActions.moveUnitDown.AddDefaultBinding (InputControlType.LeftStickDown);

	}

	void SetupAttackerActions1()
	{
		attackerActions1 = new AttackerActions();
		attackerActions1.Device = inputDevice1;

		attackerActions1.attackerAttack.AddDefaultBinding (InputControlType.Action1);

		attackerActions1.moveAttackerLeft.AddDefaultBinding (InputControlType.LeftStickLeft);
		attackerActions1.moveAttackerRight.AddDefaultBinding (InputControlType.LeftStickRight);
		attackerActions1.moveAttackerUp.AddDefaultBinding (InputControlType.LeftStickUp);
		attackerActions1.moveAttackerDown.AddDefaultBinding (InputControlType.LeftStickDown);


	}
	
	void SetupCamera()
	{
		spawnedCam = Instantiate (camPrefab, Vector3.zero, camSpawnPos.rotation) as GameObject;
		camControlScript = spawnedCam.GetComponent<CameraControl> ();

	}



	void SetupReticule()
	{
		GameObject cloneReticule = Instantiate (turretTargetPf, spawnPoints[0].position, Quaternion.identity) as GameObject;
		camControlScript.m_Targets[0] = cloneReticule.transform;
		camControlScript.m_Targets[1] = turretScript.gameObject.transform;
		turretScript.targetReticule = cloneReticule.transform;
	}

	void SetupAttackers()
	{
		for (int i = 2; i < numAttackers + 2; i++) 
		{
			GameObject clonePlayer = Instantiate (attackingPlayerPf, spawnPoints [i].position, Quaternion.identity) as GameObject;
			//Debug.Log ("pos: "+ attackerSpawnPoints [i].position);
			PlayerHealth playerHealth = clonePlayer.GetComponent<PlayerHealth>();
			playerHealth.damageImage = damageImage1;
			playerHealth.healthSlider = healthSlider1;
			camControlScript.m_Targets[i]  = clonePlayer.transform;
//			Debug.Log ("cct " + camControlScript.m_Targets[i]);
		}

	}

	void AddResource(resourceColor collectedResource)

	{
		if (collectedResource == neededColor) 
		{
		
		}
	}


}

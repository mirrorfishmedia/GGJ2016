using UnityEngine;
using System.Collections;
using InControl;

public class GameMan : MonoBehaviour {

	public Transform[] sceneDestinations;
	public SpawnMonks monkSpawner;
	public MonkActions monkCtrlActions;
	public AttackerActions attackerActions1;

	public int numPlayers = 2;
	public InputDevice inputDevice0;
	public InputDevice inputDevice1;


	void Awake()
	{
		inputDevice0 = InputManager.Devices [0];
		inputDevice1 = InputManager.Devices [1];
	}

	// Use this for initialization
	void Start () 
	{

		monkSpawner.spawnerDestinations = sceneDestinations;
		SetUpDefenderActions ();
		SetupAttackerActions ();
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

	void SetupAttackerActions()
	{
		attackerActions1 = new AttackerActions();
		attackerActions1.Device = inputDevice1;

		attackerActions1.moveAttackerLeft.AddDefaultBinding (InputControlType.LeftStickLeft);
		attackerActions1.moveAttackerRight.AddDefaultBinding (InputControlType.LeftStickRight);
		attackerActions1.moveAttackerUp.AddDefaultBinding (InputControlType.LeftStickUp);
		attackerActions1.moveAttackerDown.AddDefaultBinding (InputControlType.LeftStickDown);


	}

	// Update is called once per frame
	void Update () {
	
	}
}

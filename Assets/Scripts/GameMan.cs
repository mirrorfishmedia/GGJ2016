using UnityEngine;
using System.Collections;
using InControl;

public class GameMan : MonoBehaviour {

	public Transform[] sceneDestinations;
	public SpawnMonks monkSpawner;
	public MonkActions monkCtrlActions;


	// Use this for initialization
	void Start () 
	{
		monkSpawner.spawnerDestinations = sceneDestinations;
		SetUpActions ();
	}

	void SetUpActions()
	{
		monkCtrlActions = new MonkActions();
		Grid.gameMan.monkCtrlActions = monkCtrlActions;
		
		//monkCtrlActions.spawn0.AddDefaultBinding (Key.);
		//bfActions.jukeLeft.AddDefaultBinding (Key.A);
		monkCtrlActions.spawn0.AddDefaultBinding (InputControlType.Action1);
		monkCtrlActions.spawn1.AddDefaultBinding (InputControlType.Action2);
		monkCtrlActions.spawn2.AddDefaultBinding (InputControlType.Action3);
		monkCtrlActions.spawn3.AddDefaultBinding (InputControlType.Action4);
	}

	// Update is called once per frame
	void Update () {
	
	}
}

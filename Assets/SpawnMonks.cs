using UnityEngine;
using System.Collections;
using InControl;


public class SpawnMonks : MonoBehaviour {

	public float spawnRate = .25f;

	public GameObject monkPf;
	public Transform[] spawnPoints;

	public Transform[] spawnerDestinations;

	public enum MonkColor { Red,Blue,Green,Yellow }

	private MonkActions monkCtrlActions;
	private float nextSpawn;

	void Start () {
		
		/*monkCtrlActions = new MonkActions();
		Grid.gameMan.monkCtrlActions = monkCtrlActions;
		
		//monkCtrlActions.spawn0.AddDefaultBinding (Key.);
		//bfActions.jukeLeft.AddDefaultBinding (Key.A);
		monkCtrlActions.spawn0.AddDefaultBinding (InputControlType.Action1);
		monkCtrlActions.spawn1.AddDefaultBinding (InputControlType.Action2);
		monkCtrlActions.spawn2.AddDefaultBinding (InputControlType.Action3);
		monkCtrlActions.spawn3.AddDefaultBinding (InputControlType.Action4);

		//bfActions.jukeLeft.Sensitivity = .9f;
		bfActions.jukeLeft.RepeatDelay = Grid.playerAllStats.jukeCoolDown;
		
		bfActions.jukeRight.AddDefaultBinding (Key.RightArrow);
		bfActions.jukeRight.AddDefaultBinding (Key.D);
		bfActions.jukeRight.AddDefaultBinding (InputControlType.RightBumper);
		//bfActions.jukeRight.Sensitivity = .9f;
		bfActions.jukeRight.RepeatDelay = Grid.playerAllStats.jukeCoolDown;
		
		bfActions.shoot1.AddDefaultBinding (Key.Key1);
		bfActions.shoot1.AddDefaultBinding (Mouse.LeftButton);
		bfActions.shoot1.AddDefaultBinding (InputControlType.RightTrigger);
		
		bfActions.shoot2.AddDefaultBinding (Key.Key2);
		bfActions.shoot2.AddDefaultBinding (Mouse.RightButton);
		bfActions.shoot2.AddDefaultBinding (InputControlType.LeftTrigger);
		
		//		bfActions.shield.AddDefaultBinding (Key.Space);
		//		bfActions.shield.AddDefaultBinding (Mouse.MiddleButton);
		//		bfActions.shield.AddDefaultBinding (InputControlType.Action2);
		
		bfActions.jukeFwd.AddDefaultBinding (Key.W);
		bfActions.jukeFwd.AddDefaultBinding (Key.UpArrow);
		bfActions.jukeFwd.AddDefaultBinding (InputControlType.Action1);
		
		bfActions.jukeBack.AddDefaultBinding (Key.S);
		bfActions.jukeBack.AddDefaultBinding (Key.DownArrow);
		bfActions.jukeBack.AddDefaultBinding (InputControlType.Action2);
		
		
		bfActions.speedUp.AddDefaultBinding (Key.Space);
		//bfActions.speedUp.AddDefaultBinding (Key.UpArrow);
		//bfActions.speedUp.AddDefaultBinding (InputControlType.Action1);
		//bfActions.turn.AddDefaultBinding(Mouse.
		*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Grid.gameMan.monkCtrlActions.spawn0 && Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[0], spawnerDestinations[0]);
		}

		else if (Grid.gameMan.monkCtrlActions.spawn1 && Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[1], spawnerDestinations[1]);
		}

		else if (Grid.gameMan.monkCtrlActions.spawn2 && Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[2], spawnerDestinations[2]);
		}

		else if (Grid.gameMan.monkCtrlActions.spawn3 && Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[3], spawnerDestinations[3]);
		}

	}

	void SpawnMonk(Transform homeSpawn, Transform monkDestination)
	{
		GameObject monkClone = Instantiate (monkPf, homeSpawn.position, Quaternion.identity) as GameObject;
		MonkController monkController = monkClone.GetComponent<MonkController>();
		monkController.destStack = monkDestination;
		monkController.home = homeSpawn;
	}

}

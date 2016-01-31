using UnityEngine;
using System.Collections;
using InControl;

public class DefendingPlayer : MonoBehaviour {

	public MonkActions monkActions;

	private TurretShoot turret;
	private SpawnMonks spawner;
	private MoveReticule reticule;


	public void Awake(){
		turret = GetComponent<TurretShoot>();
		spawner = GetComponent<SpawnMonks>();
		reticule = GetComponent<MoveReticule>();
	}

	public void Init(InputDevice device, Transform[] spawnPoints){
		CameraControl.main.AddTarget(this.transform);

		monkActions = new MonkActions(device);

		turret.Init(monkActions);
		spawner.Init(monkActions, spawnPoints);

		reticule = PrefabManager.Instantiate ("TurretTargetReticule", Vector3.zero, Quaternion.identity).GetComponent<MoveReticule>();
		reticule.Init(monkActions);
		turret.targetReticule = reticule.transform;
	}


}

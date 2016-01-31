using UnityEngine;
using System.Collections;
using InControl;


public class SpawnMonks : MonoBehaviour {

	public float spawnRate = .25f;

	public GameObject monkPf;
	public Transform[] spawnPoints;

	public Transform[] spawnerDestinations;

	public enum MonkColor { Red,Blue,Green,Yellow }

	private MonkActions monkActions;
	private float nextSpawn;

	public void Init(MonkActions monkActions, Transform[] spawnerDestinations){
		this.monkActions = monkActions;
		this.spawnerDestinations = spawnerDestinations;
	}

	// Update is called once per frame
	void Update () {
		if (monkActions == null) return;

		if (monkActions.spawn0 && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[0], spawnerDestinations[0]);
		}

		else if (monkActions.spawn1 && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[1], spawnerDestinations[1]);
		}

		else if (monkActions.spawn2 && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[2], spawnerDestinations[2]);
		}

		else if (monkActions.spawn3 && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[3], spawnerDestinations[3]);
		}

	}

	void SpawnMonk(Transform homeSpawn, Transform monkDestination){
		GameObject monkClone = Instantiate (monkPf, homeSpawn.position, Quaternion.identity) as GameObject;
		MonkController monkController = monkClone.GetComponent<MonkController>();
		monkController.destStack = monkDestination;
		monkController.home = homeSpawn;
	}

}

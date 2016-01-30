using UnityEngine;
using System.Collections;

public class SpawnMonks : MonoBehaviour {

	public float spawnRate = .25f;

	public GameObject monkPf;
	public Transform[] spawnPoints;

	public Transform[] spawnerDestinations;

	public enum MonkColor { Red,Blue,Green,Yellow }

	private MonkActions monkCtrlActions;
	private float nextSpawn;

	// Use this for initialization
	void Start () 
	{
		//InvokeRepeating ("SpawnCycle", 0, spawnRate);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[0], spawnerDestinations[0]);
		}

		if (Input.GetButtonDown ("Jump") && Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			SpawnMonk(spawnPoints[1], spawnerDestinations[1]);
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

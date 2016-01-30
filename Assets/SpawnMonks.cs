using UnityEngine;
using System.Collections;

public class SpawnMonks : MonoBehaviour {

	public float spawnRate = .25f;

	public GameObject monkPf;
	public Transform spawnPoint1;

	public Transform destination1;

	public enum MonkColor { Red,Blue,Green,Yellow }

	private bool spawningType1;
	private bool spawningType2;
	private bool spawningType3;
	private bool spawningType4;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnCycle", 0, spawnRate);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			spawningType1 = true;
		}
		if (Input.GetButtonUp ("Fire1")) 
		{
			spawningType1 = false;
		}

	}

	void SpawnCycle()
	{
		if (spawningType1) 
		{
			GameObject monkClone = Instantiate (monkPf, spawnPoint1.position, Quaternion.identity) as GameObject;
			MonkController monkController = monkClone.GetComponent<MonkController>();
			monkController.destStack = destination1;
			monkController.home = this.transform;
		}

	}

}

using UnityEngine;
using System.Collections;

public class GameMan : MonoBehaviour {

	public Transform blueDestination;
	public SpawnMonks monkSpawner;


	// Use this for initialization
	void Start () 
	{
		monkSpawner.destination1 = blueDestination;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

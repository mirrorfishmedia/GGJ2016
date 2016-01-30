using UnityEngine;
using System.Collections;

public class GameMan : MonoBehaviour {

	public Transform[] sceneDestinations;
	public SpawnMonks monkSpawner;
	public MonkActions monkCtrlActions;


	// Use this for initialization
	void Start () 
	{
		monkSpawner.spawnerDestinations = sceneDestinations;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

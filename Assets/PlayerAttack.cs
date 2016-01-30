using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {


	public float attackRate = .25f;
	private float nextAttackTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Grid.gameMan.monkCtrlActions.fireTurret && Time.time > nextAttackTime) 
		{
			nextAttackTime = Time.time + attackRate;

			
		}
	}
}

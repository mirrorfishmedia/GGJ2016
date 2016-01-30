using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject attackSphere;
	public float attackRate = .25f;
	private float nextAttackTime;
	public float attackLength;


	private bool attacking;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Grid.gameMan.attackerActions1.attackerAttack && Time.time > nextAttackTime && !attacking) {
			nextAttackTime = Time.time + attackRate;
			attacking = true;
			attackSphere.SetActive (true);
			
		} else 
		{
			if (attacking)
			{
				Invoke ("DeactivateSphere", attackLength);
			}

		}
	}

	void DeactivateSphere()
	{
		attacking = false;
		attackSphere.SetActive (false);
	}
}

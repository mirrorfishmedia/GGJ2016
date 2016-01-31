using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private AttackDamage attackSphere;

	private float attackRate = .25f;
	private float attackLength = .2f;

	private float nextAttackTime;


	private bool attacking;

	private AttackerActions attackerActions;
	public void Init(AttackerActions attackerActions){
		this.attackerActions = attackerActions;
	}

	void Awake(){
		attackSphere = GetComponentInChildren<AttackDamage>();
		attackSphere.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (attackerActions.attackerAttack && Time.time > nextAttackTime && !attacking) {
			nextAttackTime = Time.time + attackRate;
			attacking = true;
			attackSphere.gameObject.SetActive (true);
			CameraShake.main.microShakeDuration = .2f;

		} else 
		{
			if (attacking){
				Invoke ("DeactivateSphere", attackLength);
			}

		}
	}

	void DeactivateSphere()
	{
		attacking = false;
		attackSphere.gameObject.SetActive (false);
	}
}

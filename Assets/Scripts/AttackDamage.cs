using UnityEngine;
using System.Collections;

public class AttackDamage : MonoBehaviour {

	private int damageAmount = 2;

	private bool triggering;



	void OnTriggerEnter(Collider other)
	{
//		Debug.Log ("trigger attack");
		if (other.gameObject.CompareTag ("Monk") && !triggering) 
		{
			triggering = true;
//			Debug.Log ("Collision attack, tag check");
//			Debug.Log ("other gameobject " + other.gameObject);
			PlayerHealth health = other.GetComponent<PlayerHealth>();

			health.TakeDamage(damageAmount);
		}

		if (other.gameObject.CompareTag ("Projectile")) {
			other.gameObject.SetActive(false);
		}
	}

	/*

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("collision attack");
		if (col.gameObject.CompareTag ("Monk") && !triggering) 
		{
			triggering = true;
			Debug.Log ("Collision attack, tag check");
			Debug.Log ("other gameobject " + col.gameObject);
			EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
			
			enemyHealth.TakeDamage(damageAmount, col.transform.position);
		}
		
		if (col.gameObject.CompareTag ("Projectile")) {
			col.gameObject.SetActive(false);
		}
	}
	*/



	void OnDisable()
	{
		triggering = false;
	}

}

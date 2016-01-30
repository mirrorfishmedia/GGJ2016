using UnityEngine;
using System.Collections;

public class AttackDamage : MonoBehaviour {

	public int damageAmount = 25;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("trigger attack");
		if (other.gameObject.CompareTag ("Monk")) 
		{
			Debug.Log ("Collision attack, tag check");
			Debug.Log ("other gameobject " + other.gameObject);
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(damageAmount, other.transform.position);
		}
	}

	void OnCollisionEnter (Collision other)
	{
		Debug.Log ("Collision attack");


	}
}

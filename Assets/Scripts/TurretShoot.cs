using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour {

	public GameObject projectilePf;
	public float fireRate;
	public Transform targetReticule;
	public float projectileSpeed = 100;

	private float nextFire;

	// Use this for initialization
	void OnEnable () 
	{
		Grid.gameMan.turretScript = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Grid.gameMan.monkCtrlActions.fireTurret && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			GameObject cloneProjectile = Instantiate(projectilePf, transform.position, transform.rotation) as GameObject;
			Vector3 dirToTarget = targetReticule.position - transform.position;
			Rigidbody cloneRb = cloneProjectile.GetComponent<Rigidbody>();
			cloneRb.AddForce(dirToTarget.normalized * projectileSpeed);

		}
	}
}

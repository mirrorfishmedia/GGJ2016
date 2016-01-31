using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour {

	private MonkActions monkActions;

	public GameObject projectilePf;
	public float fireRate;
	public Transform targetReticule;
	public float projectileSpeed = 100;
	public Transform spawnPoint;

	private float nextFire;

	public void Init(MonkActions monkActions){
		this.monkActions = monkActions;
	}


	// Update is called once per frame
	void Update () {

		if (monkActions == null) return;

		if (monkActions.fireTurret && Time.time > nextFire){
			Fire();
		}
	}

	void Fire(){
		nextFire = Time.time + fireRate;
		GameObject cloneProjectile = Instantiate(projectilePf, spawnPoint.position, Quaternion.identity) as GameObject;
		Vector3 dirToTarget = targetReticule.position - transform.position;
		Rigidbody cloneRb = cloneProjectile.GetComponent<Rigidbody>();
		cloneRb.AddForce(dirToTarget.normalized * projectileSpeed);
		Grid.soundMan.FireTurret ();
	}

}

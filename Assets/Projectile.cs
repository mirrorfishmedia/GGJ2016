using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject particles;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision other)
	{
		particles.SetActive (true);
		particles.transform.SetParent (null);
		this.gameObject.SetActive (false);
	}
}

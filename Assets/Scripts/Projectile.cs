﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject particles;
	public GameObject trail;

	private int bulletDamage = 2;


	private PlayerHealth playerHealth;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		trail.transform.SetParent(null);
		Destroy(trail, 5f);
		particles.SetActive (true);
		particles.transform.SetParent (null);
		this.gameObject.SetActive (false);
		if(other.gameObject.CompareTag("Player"))
		{
			playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.TakeDamage (bulletDamage);
		}
	}
	
}

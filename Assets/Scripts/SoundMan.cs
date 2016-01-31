using UnityEngine;
using System.Collections;

public class SoundMan : MonoBehaviour {


	float randomizeMin = .70f;
	float randomizeMax = 1.2f;


	public AudioClip[] fireTurretClips;
	public AudioClip[] monkDieClips;
	public AudioClip[] monkHitClips;
	public AudioClip[] monkSpawnClips;
	public AudioClip[] outOfTimeClips;
	public AudioClip[] playerAttackClip;
	public AudioClip[] playerDeathClips;
	public AudioClip[] playerHitClips;
	public AudioClip[] resourceCollectClips;
	public AudioClip[] resourcePickupClip;
	public AudioClip[] singleColorScoredClips;


	private AudioSource source; 

	// Use this for initialization
	void OnEnable () 
	{
		source = GetComponent<AudioSource> ();
	}

	public void FireTurret()
	{
		PlayClip (fireTurretClips);
	}

	public void MonkDie()
	{
		PlayClip (monkDieClips);
	}

	public void MonkHit()
	{
		PlayClip (monkHitClips);
	}

	public void MonkSpawn()
	{
		PlayClip (monkSpawnClips);
	}

	public void OutOfTime()
	{
		PlayClip (outOfTimeClips);
	}

	public void PlayerAttack()
	{
		PlayClip (playerAttackClip);
	}

	public void PlayerDeath()
	{
		PlayClip (playerDeathClips);
	}

	public void PlayerHit()
	{
		PlayClip (playerHitClips);
	}

	public void ResourceCollect()
	{
		PlayClip (resourceCollectClips);
	}

	public void ResourcePickup()
	{
		PlayClip (resourcePickupClip);
	}

	public void ColorScored()
	{
		PlayClip (singleColorScoredClips);
	}

	public void PlayClip(AudioClip[] clips)
	{
		source.clip = clips[Random.Range (0, clips.Length)];
		source.volume = Random.Range (randomizeMin, randomizeMax);
		source.pitch = Random.Range (randomizeMin, randomizeMax);
		source.Play ();
	}
}

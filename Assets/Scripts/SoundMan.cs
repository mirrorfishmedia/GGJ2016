using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundMan : MonoBehaviour {

	public static SoundMan main;

	public AudioMixerSnapshot fightMusic;
	public AudioMixerSnapshot titleMusic;

	float randomizeMin = .70f;
	float randomizeMax = 1.2f;

	public AudioClip[] bellSelect;

	public AudioClip[] altarAnimation;

	public AudioClip[] fireTurretClips;
	public AudioClip[] monkDieClips;
	public AudioClip[] monkHitClips;
	public AudioClip[] monkSpawnClips;
	public AudioClip[] outOfTimeClips;
	public AudioClip[] playerAttackClip;
	public AudioClip[] playerDeathClips;
	public AudioClip[] playerHitClips;
	public AudioClip[] resourceCollectClips;

	public AudioClip[] resourceCollectSkull;
	public AudioClip[] resourceCollectTriangle;
	public AudioClip[] resourceCollectFire;
	public AudioClip[] resourceCollectRaven;

	public AudioClip[] resourceDepositSkull;
	public AudioClip[] resourceDepositTriangle;
	public AudioClip[] resourceDepositFire;
	public AudioClip[] resourceDepositRaven;


	public AudioClip[] resourcePickupClip;
	public AudioClip[] singleColorScoredClips;

	private int audioSourceCounter = 0;
	public AudioSource[] audioSources;

	private AudioSource source; 

	// Use this for initialization
	void OnEnable () 
	{
		main = this;
		source = GetComponent<AudioSource> ();
	}

	void Start()
	{
	
		audioSources = new AudioSource[64];
		for (int i = 0; i < audioSources.Length; i++) {
		
			var a = new GameObject ("AudioSource" + i).AddComponent <AudioSource> ();
			a.transform.SetParentZeroed (this.transform);
			audioSources [i] = a;

		}

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

	public void ResourceCollectRaven()
	{
		PlayClip (resourceCollectRaven);
	}

	public void ResourceCollectSkull()
	{
		PlayClip (resourceCollectSkull);
	}

	public void ResourceCollectFireball()
	{
		PlayClip (resourceCollectFire);
	}

	public void ResourceCollectTriangle()
	{
		PlayClip (resourceCollectTriangle);
	}

	public void ResourceDepositSkull()
	{
		PlayClip (resourceDepositSkull);
	}

	public void ResourceDepositRaven()
	{
		PlayClip (resourceDepositRaven);
	}

	public void ResourceDepositFireball()
	{
		PlayClip (resourceDepositFire);
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
		/*
		source.clip = clips[Random.Range (0, clips.Length)];
		source.volume = Random.Range (randomizeMin, randomizeMax);
		source.pitch = Random.Range (randomizeMin, randomizeMax);

		source.Play ();

*/
		audioSourceCounter = (audioSourceCounter + 1) % audioSources.Length;
		var a = audioSources [audioSourceCounter];

		a.clip = clips[Random.Range (0, clips.Length)];
		a.volume = Random.Range (randomizeMin, randomizeMax);
		a.pitch = Random.Range (randomizeMin, randomizeMax);
		a.Play ();

	}

	public void StartTitleMusic()
	{
		titleMusic.TransitionTo (1f);
	}

	public void StartFightMusic()
	{
		fightMusic.TransitionTo (1f);
	}
}


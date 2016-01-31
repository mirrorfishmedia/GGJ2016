using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
	private int startingHealth = 4;                             // The amount of health the player starts the game with.
	public int currentHealth{get; private set;}                 // The current health the player has
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.

	public event EventHandler OnTakeDamage;
	public event EventHandler OnDie;

	
	AudioSource playerAudio;                                    // Reference to the AudioSource component.
	MoveAttacker moveAttacker;                              // Reference to the player's movement.
	//PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
	bool isDead;                                                // Whether the player is dead.

	
	void Awake ()
	{
		// Setting up the references.
		playerAudio = GetComponent <AudioSource> ();
		moveAttacker = GetComponent <MoveAttacker> ();

		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	

	public void TakeDamage (int amount)
	{

		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		OnTakeDamage.Raise(this);
		
		// Play the hurt sound effect.
		//playerAudio.Play ();
		Grid.soundMan.PlayerHit ();
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}
	
	
	void Death ()
	{
		OnDie.Raise(this);
		// Set the death flag so this function won't be called again.
		isDead = true;
		gameObject.SetActive (false);
		// Turn off any remaining shooting effects.
		//playerShooting.DisableEffects ();
		
		// Tell the animator that the player is dead.
//		anim.SetTrigger ("Die");
		
		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
		playerAudio.clip = deathClip;
		playerAudio.Play ();
		
	}       
}
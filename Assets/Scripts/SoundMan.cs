using UnityEngine;
using System.Collections;

public class SoundMan : MonoBehaviour {

	public AudioSource source; 

	// Use this for initialization
	void OnEnable () 
	{
		source = GetComponent<AudioSource> ();
	}
	
	public void PlayClip(AudioClip clip)
	{
		source.clip = clip;
		source.Play ();
	}
}

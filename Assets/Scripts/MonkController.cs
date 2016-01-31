using UnityEngine;
using System.Collections;

public class MonkController : MonoBehaviour {

	private NavMeshAgent agent;

	public Transform destStack;
	public Transform home;
	public GameObject resource1;
	public AudioClip pickupResourceSound;
	public AudioClip deliverResourceSound;
	//public AudioClip spawnSound;
	public AudioClip dieSound;


	private AudioSource source;

	private bool carryingResource = false;

	private GameMan.resourceColor resourceCarried;

	// Use this for initialization
	void OnEnable () 
	{
		agent = GetComponent<NavMeshAgent>();
		source = GetComponent<AudioSource> ();

	}

	void Start()
	{
		agent.destination = destStack.position;
		agent.updateRotation = false;
	}

	void Die()
	{
		source.clip  = dieSound;
		source.Play();
	}

	void Update()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Leaf")) 
		{
			carryingResource = true;
			resourceCarried = GameMan.resourceColor.leaf;
			SetResourceIcon (resourceCarried);
			agent.destination = home.position;
		}

		if (other.gameObject.CompareTag ("Water")) 
		{
			carryingResource = true;
			resourceCarried = GameMan.resourceColor.water;
			SetResourceIcon (resourceCarried);
			agent.destination = home.position;
		}

		if (other.gameObject.CompareTag ("Fire")) 
		{
			carryingResource = true;
			resourceCarried = GameMan.resourceColor.fire;
			SetResourceIcon (resourceCarried);
			agent.destination = home.position;
		}

		if (other.gameObject.CompareTag ("Skull")) 
		{
			carryingResource = true;
			resourceCarried = GameMan.resourceColor.skull;
			SetResourceIcon (resourceCarried);
			agent.destination = home.position;
		}



		if (other.gameObject.CompareTag ("DropPoint")) 
		{
			if (carryingResource)
			{
				Grid.gameMan.AddResource(resourceCarried);
				Grid.soundMan.PlayClip(deliverResourceSound);
				carryingResource = false;
				this.gameObject.SetActive(false);
			}
		}
	}

	void SetResourceIcon(GameMan.resourceColor iconType)
	{
		switch (iconType) 
		{
		case GameMan.resourceColor.fire:
			//set icon active
			Debug.Log ("Carrying Resource: " + iconType);
			break;
		case GameMan.resourceColor.water:
			//set icon active
			break;
		case GameMan.resourceColor.leaf:
			//set icon active
			break;
		case GameMan.resourceColor.skull:
			//set icon active
			break;
		}
		Debug.Log ("Carrying Resource: " + iconType);
	}
}

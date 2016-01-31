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

	private ResourceType resourceCarried;

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

	void Die(){
		source.clip  = dieSound;
		source.Play();
	}

	void CarryResource(ResourceType rtype){
		this.carryingResource = true;
		this.resourceCarried = rtype;
		SetResourceIcon (resourceCarried);
		agent.SetDestination(home.transform.position);
	}

	void ScoreResource(){
		if (carryingResource){
			carryingResource = false;
			Grid.gameMan.AddResource(resourceCarried);
			Grid.soundMan.PlayClip(deliverResourceSound);
			this.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		var g = other.gameObject;

		//carry resource
		if (g.CompareTag("ResourceStack")){
			var r = g.GetComponent<ResourceStack>();
			CarryResource(r.rtype);
		}


		else if (g.CompareTag ("DropPoint")) {
			ScoreResource();
		}
	}

	void SetResourceIcon(ResourceType iconType)
	{
//		switch (iconType) 
//		{
//		case GameMan.resourceColor.fire:
//			//set icon active
//			Debug.Log ("Carrying Resource: " + iconType);
//			break;
//		case GameMan.resourceColor.water:
//			//set icon active
//			break;
//		case GameMan.resourceColor.leaf:
//			//set icon active
//			break;
//		case GameMan.resourceColor.skull:
//			//set icon active
//			break;
//		}
//		Debug.Log ("Carrying Resource: " + iconType);
	}
}

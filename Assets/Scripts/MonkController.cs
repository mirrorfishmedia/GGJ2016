using UnityEngine;
using System.Collections;

public class MonkController : Unit {

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

	private PlayerHealth health;


	// Use this for initialization
	public override void Awake () {
		base.Awake();
		agent = GetComponent<NavMeshAgent>();
		source = GetComponent<AudioSource> ();
		CameraControl.main.AddTarget(this);
	}

	void Start()
	{
		agent.destination = destStack.position;
		agent.updateRotation = false;
		Grid.soundMan.MonkSpawn ();
	}


	void Die(){
		source.clip  = dieSound;
		source.Play();
		Grid.soundMan.MonkDie ();
	}

	void CarryResource(ResourceType rtype){

		this.carryingResource = true;
		this.resourceCarried = rtype;
		SetResourceIcon (resourceCarried);
		agent.SetDestination(home.transform.position);
		Grid.soundMan.ResourcePickup();
	}

	void ScoreResource(){
		if (carryingResource){
			carryingResource = false;
			Grid.gameMan.AddResource(resourceCarried);
			Grid.soundMan.ResourceCollect();
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

	void OnDisable(){
		CameraControl.main.RemoveTarget(this);
	}
}

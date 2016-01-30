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

	/*
	void LateUpdate()
	{
		float angle = Vector3.Angle(agent.velocity.normalized, this.transform.forward);
		if (agent.velocity.normalized.x < this.transform.forward.x)
		{
			angle *= -1;
		}
		angle = (angle + 180.0f) % 360.0f;
	}
	*/

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("ResourceStack")) 
		{
			carryingResource = true;
			resource1.SetActive(true);
			agent.destination = home.position;

			//transform.LookAt(agent.destination);
			//source.clip  = pickupResource;
			//source.Play();

		}

		if (other.gameObject.CompareTag ("DropPoint")) 
		{

			//agent.Stop();
			//transform.LookAt(agent.destination);
			if (carryingResource)
			{
				Grid.soundMan.PlayClip(deliverResourceSound);

				carryingResource = false;
				this.gameObject.SetActive(false);

			}
				

		}


	}
}

using UnityEngine;
using System.Collections;

public class MonkController : MonoBehaviour {

	private NavMeshAgent agent;

	public Transform destStack;
	public Transform home;
	public GameObject resource1;


	private bool carryingResource = false;

	// Use this for initialization
	void OnEnable () 
	{
		agent = GetComponent<NavMeshAgent>();
		agent.destination = destStack.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("ResourceStack")) 
		{
			carryingResource = true;
			resource1.SetActive(true);
			agent.destination = home.position;
			transform.LookAt(agent.destination);
		}

		if (other.gameObject.CompareTag ("DropPoint")) 
		{
			carryingResource = false;
			resource1.SetActive(false);
			agent.destination = destStack.position;
			transform.LookAt(agent.destination);
		}


	}
}

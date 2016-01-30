using UnityEngine;
using System.Collections;

public class turn : MonoBehaviour {

	public float direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, direction, 0);
//		transform.Rotate (Vector3 y, Time.deltaTime * 10, Space.Self);
	}

}

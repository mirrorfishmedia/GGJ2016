using UnityEngine;
using System.Collections;

public class YOLO : MonoBehaviour {

	void GOGO(){
		gameObject.SetActive (true);
	}

	// Use this for initialization
	void Awake () {
		gameObject.SetActive (false);
		Invoke ("GOGO", 3f);
	}
	
}

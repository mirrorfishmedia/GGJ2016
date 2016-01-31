using UnityEngine;
using System.Collections;

public class SortingLayerHelper : MonoBehaviour {

	SpriteRenderer rend;

	void Awake(){
		rend = GetComponent<SpriteRenderer>();
		if (rend == null) Destroy(this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rend.sortingOrder = Mathf.RoundToInt(transform.position.z * 10f) * -1;
	}
}

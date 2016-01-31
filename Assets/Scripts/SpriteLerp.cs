using UnityEngine;
using System.Collections;

public class SpriteLerp : MonoBehaviour {

	public Color endColor = Color.white;
	public float speed = 1f;

	SpriteRenderer rend;
	void Awake(){
		rend = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		rend.color = Color.Lerp(rend.color, endColor, Time.deltaTime * speed);
	}
}

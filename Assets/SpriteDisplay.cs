using UnityEngine;
using System.Collections;

public class SpriteDisplay : MonoBehaviour {

	public Sprite[] sprites;
	private float fadeSpeed = 1f;

	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		//spriteRenderer.color = Color.Lerp(Color.white, Color.black,Time.time);
	}
}

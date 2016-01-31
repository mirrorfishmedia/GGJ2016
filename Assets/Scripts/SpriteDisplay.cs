using UnityEngine;
using System.Collections;

public class SpriteDisplay : MonoBehaviour {

	bool active = false;
	public Sprite[] sprites;
	private float fadeSpeed = 5f;

	private SpriteRenderer spriteRenderer;

	public void SetResourceIcon(ResourceType type)
	{
		spriteRenderer.sprite = sprites[(int)type];
	}

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		spriteRenderer.color = Color.Lerp(spriteRenderer.color, active ? Color.white : Color.clear, Time.deltaTime * fadeSpeed);
	}

	public void SetFadeActive(bool active){
		this.active = active;
		this.transform.localScale = active ? Vector3.one : transform.localScale;
	}
}

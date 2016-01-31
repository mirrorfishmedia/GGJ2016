using UnityEngine;
using System.Collections;

public class HealthIndicator : MonoBehaviour {

	public Sprite onSprite;
	public Sprite offSprite;

	SpriteRenderer spriteRenderer;

	bool on = true;

	void Awake(){
		spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		AnimateActive(true);
	}

	public void Init(Sprite onSprite){
//		Debug.Log(onSprite.name);
		if (onSprite != null)
			this.onSprite = onSprite;
		AnimateActive(true);
	}

	public void AnimateActive(bool active){
		this.on = active;
		spriteRenderer.sprite = on ? onSprite : offSprite;
	}


}

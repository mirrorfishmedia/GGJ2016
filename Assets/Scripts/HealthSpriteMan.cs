using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthSpriteMan : MonoBehaviour {

	private int maxHealth = 4;
	private float offset = 2.25f;
	private List<HealthIndicator> indicators; 

	private Transform indicatorFolder;

	public bool playAttackerHitSound = false;

	public void Init(Sprite onSprite){
		for(int i = 0; i < indicators.Count; i++){
			indicators[i].Init(onSprite);
		}
	}

	void Awake(){
		indicators = new List<HealthIndicator>();
		indicatorFolder = new GameObject("Indicators").transform;
		indicatorFolder.SetParentZeroed(this.transform);
		for(int i = 0; i < maxHealth; i++){
			var indicator = PrefabManager.Instantiate("HealthIndicator", Vector3.zero).GetComponent<HealthIndicator>();
			indicators.Add(indicator);
			indicator.transform.SetParentZeroed(indicatorFolder);
			indicator.transform.localPosition = new Vector3(4f, i * offset - 2.5f, 0f);
			indicator.transform.localRotation = Quaternion.identity;
			indicator.transform.localScale = Vector3.one * 1f;
		}
	}

	public void SetHealth(int health){
		for(int i = 0; i < indicators.Count; i++){
			indicators[i].AnimateActive(i < health);
			if (playAttackerHitSound)
			{
				Grid.soundMan.PlayerHit();
			}
			else
			{
				Grid.soundMan.MonkHit();
			}
		}
	}

}

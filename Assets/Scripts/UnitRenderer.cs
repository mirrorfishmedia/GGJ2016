using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum UnitColor{
	Monk, Red, Gold, Green, Black
}

public class UnitRenderer : MonoBehaviour{

	public UnitColor color{get; private set;}

	public HealthSpriteMan hsm{get; private set;}

	public SpriteRenderer spr{get; private set;}

	private List<Sprite[]> playerSprites;
	public Sprite[] playerSpritesMonk;
	public Sprite[] playerSpritesRed;
	public Sprite[] playerSpritesGold;
	public Sprite[] playerSpritesGreen;
	public Sprite[] playerSpritesBlack;

	public Sprite[] sprites;

	void Awake(){
		spr = GetComponent<SpriteRenderer>();
		playerSprites = new List<Sprite[]>();
		playerSprites.Add(playerSpritesMonk);
		playerSprites.Add(playerSpritesRed);
		playerSprites.Add(playerSpritesGold);
		playerSprites.Add(playerSpritesGreen);
		playerSprites.Add(playerSpritesBlack);
		hsm = gameObject.AddComponent<HealthSpriteMan>();

	}



	public static UnitRenderer New(UnitColor color){
		var ans = PrefabManager.Instantiate("UnitRenderer").GetComponent<UnitRenderer>(); 
		ans.Init(color);
		return ans;
	}

	public void Init(UnitColor color){
		this.color = color;
		int index = (int)color;
		var playerSprite = playerSprites[index][0];
		var healthOnSprite = sprites[index];
		hsm.Init(healthOnSprite);
		spr.sprite = playerSprite;
	}

}

using UnityEngine;
using System.Collections;

public class HealthSpriteMan : MonoBehaviour {

	public GameObject[] healthSprites;

	public void SetSprite(int currentHealth)
	{
		for (int i = 0; i < healthSprites.Length; i++) 
		{
			healthSprites[i].SetActive(false);
		}
		healthSprites[currentHealth].SetActive(true);
	}
}

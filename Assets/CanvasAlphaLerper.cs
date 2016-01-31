using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasAlphaLerper : MonoBehaviour {


	public float target;

	public float speed;

	private CanvasGroup canvasGroup;

	// Use this for initialization
	void OnEnable () 
	{
		canvasGroup = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		canvasGroup.alpha = Mathf.Lerp (canvasGroup.alpha, target, Time.deltaTime * speed);
	}
}

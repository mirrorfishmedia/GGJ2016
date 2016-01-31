using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputTimerRenderer : MonoBehaviour {

	public Image img;


	public void SetFloat(float timeNormalized){
		img.fillAmount = timeNormalized;
	}


}

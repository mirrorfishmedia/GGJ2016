using UnityEngine;
using System.Collections;

public class SpriteRotSetter : MonoBehaviour {

	void Awake(){
		this.transform.rotation = CameraControl.rot;
	}
}

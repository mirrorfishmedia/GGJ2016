using UnityEngine;
using System.Collections;
using InControl;

public class ResourceSequence : MonoBehaviour {

	GameMan gameMan;

	InputDevice device;
	bool inputting = false;

	int currentInputIndex;
	public ResourceType[] inputArray;
	ResourceType[] checkArray;

	void Awake(){
		gameMan = GetComponent<GameMan>();
	}

	public void StartInput(InputDevice device){
		this.device = device;
		inputting = true;
		currentInputIndex = 0;
		inputArray = new ResourceType[4];
	}

	public void Update(){
		if (inputting){ InputCheck(); }
	}

	void InputCheck(){
		ResourceType t = ResourceType.NONE;
		if (device.Action1.WasReleased){
			t = ResourceType.Fire;
		}
		else if (device.Action2.WasReleased){
			t = ResourceType.Feather;
		}
		else if (device.Action3.WasReleased){
			t = ResourceType.Skull;
		}
		else if (device.Action4.WasReleased){
			t = ResourceType.Pyramid;
		}

		if (t != ResourceType.NONE){
			Debug.Log("Input " + t.ToString());
			inputArray[currentInputIndex++] = t;
			if (currentInputIndex >= 4){
				Checker();
			}
		}
	}

	void Checker(){

		bool success = CheckArray();
		if (success){
			gameMan.StartGame();
		}
		else{
			StartInput(device);
		}
	}

	bool CheckArray(){
		if (checkArray != null){
			for(int i = 0; i < inputArray.Length; i++){
				if (checkArray[i] != inputArray[i]){
					Debug.Log("FAIL REDO");
					checkArray = null;
					return false;
				}
			}
			Debug.Log("SUCCESS");
			return true;
		}
		else{
			Debug.Log("INPUT TO CONFIRM");
			if (checkArray == null) checkArray = inputArray;
			return false;
		}
	}




}

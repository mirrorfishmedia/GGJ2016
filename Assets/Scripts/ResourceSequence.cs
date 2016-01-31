using UnityEngine;
using System.Collections;
using System;
using InControl;

public class ResourceEventArgs : EventArgs{
	public int index;
	public ResourceEventArgs(int index){
		this.index = index;
	}
}

public class ResourceSequence : MonoBehaviour {

	GameMan gameMan;

	InputDevice device;
	bool inputting = false;

	int currentInputIndex;
	public ResourceType[] inputArray;
	ResourceType[] checkArray;

	public event EventHandler<ResourceEventArgs> OnInputted;
	public event EventHandler OnCheckInputTrue;
	public event EventHandler OnCheckInputFalse;
	public event EventHandler OnInputAgain;

	void Awake(){
		gameMan = GetComponent<GameMan>();
	}

	public void StartInput(InputDevice device){
		this.device = device;
		inputting = true;
		currentInputIndex = 0;
		inputArray = new ResourceType[3];
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

		if (t != ResourceType.NONE && currentInputIndex <= 2){
			Debug.Log("Input " + t.ToString());
			OnInputted.Raise(this, new ResourceEventArgs(currentInputIndex));
			inputArray[currentInputIndex++] = t;
			if (currentInputIndex >= 3){
				StartCoroutine(Checker());
			}
		}
	}

	IEnumerator Checker(){
		yield return new WaitForSeconds (1f);
		bool success = CheckArray();
		if (success){
			inputting = false;
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
					OnCheckInputFalse.Raise(this);
					checkArray = null;
					return false;
				}
			}
			Debug.Log("SUCCESS");
			OnCheckInputTrue.Raise(this);
			return true;
		}
		else{
			Debug.Log("INPUT TO CONFIRM");
			OnInputAgain.Raise(this);
			if (checkArray == null) checkArray = inputArray;
			return false;
		}
	}




}

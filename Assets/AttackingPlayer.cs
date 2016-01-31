using UnityEngine;
using System.Collections;
using InControl;

public class AttackingPlayer : MonoBehaviour {

	AttackerActions attackerActions;

	MoveAttacker motor;
	PlayerAttack atk;

	void Awake(){
		CameraControl.main.AddTarget(this.transform);

		motor = GetComponent<MoveAttacker>();
		atk = GetComponent<PlayerAttack>();
	}

	public void Init(InputDevice device){

		attackerActions = new AttackerActions(device);

		motor.Init(attackerActions);
		atk.Init(attackerActions);

	}

}

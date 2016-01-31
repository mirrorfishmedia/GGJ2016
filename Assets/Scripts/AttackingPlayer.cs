using UnityEngine;
using System.Collections;
using InControl;

public class AttackingPlayer : Unit {

	AttackerActions attackerActions;

	MoveAttacker motor;
	PlayerAttack atk;

	public override void Awake(){
		base.Awake();
		CameraControl.main.AddTarget(this.transform);

		motor = GetComponent<MoveAttacker>();
		atk = GetComponent<PlayerAttack>();
	}


	public void Init(InputDevice device, UnitColor color){
		base.Init(color);

		attackerActions = new AttackerActions(device);
		motor.Init(attackerActions);
		atk.Init(attackerActions);

	}

	public override void Health_OnTakeDamage (object sender, System.EventArgs e){
		base.Health_OnTakeDamage(sender, e);
	}

}

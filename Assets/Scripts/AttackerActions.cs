using UnityEngine;
using System.Collections;
using InControl;

public class AttackerActions : PlayerActionSet {

	public PlayerAction moveAttackerLeft;
	public PlayerAction moveAttackerRight;
	public PlayerAction moveAttackerUp;
	public PlayerAction moveAttackerDown;
	public PlayerAction attackerAttack;

	public PlayerOneAxisAction moveAttackerHorizontal;
	public PlayerOneAxisAction moveAttackerVertical;



	public AttackerActions()
	{
	
		attackerAttack = CreatePlayerAction ("AttackerAttack");

		moveAttackerLeft = CreatePlayerAction ("MoveUnitLeft");
		moveAttackerRight = CreatePlayerAction ("MoveUnitRight");
		moveAttackerHorizontal = CreateOneAxisPlayerAction (moveAttackerLeft, moveAttackerRight);
		
		
		
		moveAttackerUp = CreatePlayerAction ("MoveUnitUp");
		moveAttackerDown = CreatePlayerAction ("MoveUnitDown");
		moveAttackerVertical = CreateOneAxisPlayerAction (moveAttackerDown,moveAttackerUp);

	}
}

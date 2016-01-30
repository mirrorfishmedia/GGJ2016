using UnityEngine;
using System.Collections;
using InControl;

public class MonkActions : PlayerActionSet {
	
	public PlayerAction spawn0;
	public PlayerAction spawn1;
	public PlayerAction spawn2;
	public PlayerAction spawn3;
	public PlayerAction fireTurret;
	public PlayerAction moveUnitLeft;
	public PlayerAction moveUnitRight;
	public PlayerOneAxisAction moveHorizontal;

	public PlayerAction moveUnitUp;
	public PlayerAction moveUnitDown;
	public PlayerOneAxisAction moveVertical;


	
	public MonkActions()
	{
		spawn0 = CreatePlayerAction ("Spawn0");
		spawn1 = CreatePlayerAction ("Spawn1");
		spawn2 = CreatePlayerAction ("Spawn2");
		spawn3 = CreatePlayerAction ("Spawn3");
		fireTurret = CreatePlayerAction ("FireTurret");
		moveUnitLeft = CreatePlayerAction ("MoveUnitLeft");
		moveUnitRight = CreatePlayerAction ("MoveUnitRight");
		moveHorizontal = CreateOneAxisPlayerAction (moveUnitLeft, moveUnitRight);

		moveUnitUp = CreatePlayerAction ("MoveUnitUp");
		moveUnitDown = CreatePlayerAction ("MoveUnitDown");
		moveVertical = CreateOneAxisPlayerAction (moveUnitDown,moveUnitUp);

	}
	
}

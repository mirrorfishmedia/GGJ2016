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


	
	public MonkActions(InputDevice device)
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

		Device = device;

		spawn0.AddDefaultBinding (InputControlType.Action1);
		spawn1.AddDefaultBinding (InputControlType.Action2);
		spawn2.AddDefaultBinding (InputControlType.Action3);
		spawn3.AddDefaultBinding (InputControlType.Action4);
		fireTurret.AddDefaultBinding (InputControlType.RightTrigger);

		moveUnitLeft.AddDefaultBinding (InputControlType.LeftStickLeft);
		moveUnitRight.AddDefaultBinding (InputControlType.LeftStickRight);
		moveUnitUp.AddDefaultBinding (InputControlType.LeftStickUp);
		moveUnitDown.AddDefaultBinding (InputControlType.LeftStickDown);

	}
	
}

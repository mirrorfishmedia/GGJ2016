using UnityEngine;
using System.Collections;
using InControl;

public class MonkActions : PlayerActionSet {
	
	public PlayerAction spawn0;
	public PlayerAction spawn1;
	public PlayerAction spawn2;
	public PlayerAction spawn3;

	
	public MonkActions()
	{
		spawn0 = CreatePlayerAction ("Spawn0");
		spawn1 = CreatePlayerAction ("Spawn1");
		spawn2 = CreatePlayerAction ("Spawn2");
		spawn3 = CreatePlayerAction ("Spawn3");
	}
	
}

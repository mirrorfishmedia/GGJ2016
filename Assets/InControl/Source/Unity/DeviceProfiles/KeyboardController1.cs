using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InControl
{
	[AutoDiscover]
	public class KeyboardController1: UnityInputDeviceProfile
	{
		public KeyboardController1()
		{
			Name = "WASD Keyboard Controller";
			Meta = "WASD Keyboard Controller";
			
			SupportedPlatforms = new[]
			{
				"Windows",
				"OS X",
//				"Linux"
			};

			Sensitivity = 1.0f;
			LowerDeadZone = 0.2f;
			
			ButtonMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "A",
					Target = InputControlType.Action1,
					Source = new UnityKeyCodeSource(KeyCode.G)
				},
				new InputControlMapping
				{
					Handle = "B",
					Target = InputControlType.Action2,
					Source = new UnityKeyCodeSource(KeyCode.H)
				},
				new InputControlMapping
				{
					Handle = "X",
					Target = InputControlType.Action1,
					Source = new UnityKeyCodeSource(KeyCode.F)
				},
				new InputControlMapping
				{
					Handle = "Y",
					Target = InputControlType.Action2,
					Source = new UnityKeyCodeSource(KeyCode.T)
				},
				new InputControlMapping
				{
					Handle = "Start",
					Target = InputControlType.Start,
					Source = new UnityKeyCodeSource(KeyCode.Escape)
				},
			};
			
			AnalogMappings = new[]
			{
				LeftStickLeftMapping( new UnityKeyCodeAxisSource(KeyCode.A, KeyCode.D) ),
				LeftStickRightMapping( new UnityKeyCodeAxisSource(KeyCode.A, KeyCode.D) ),
				LeftStickUpMapping( new UnityKeyCodeAxisSource(KeyCode.W, KeyCode.S) ),
				LeftStickDownMapping( new UnityKeyCodeAxisSource(KeyCode.W, KeyCode.S) ),
			};
		}
	}
}

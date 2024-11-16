using Godot;
using System;
using System.Collections.Generic;

public partial class Globals : Node
{
	public static float globalVolume = 100;
	public static float soundVolume = 100;
	public static float musicVolume = 100;

	//public static int[,] gridPosition = new int[100, 100];
	public static Dictionary<Vector2, E_Buildings> gridPositions = new Dictionary<Vector2, E_Buildings>();
	public enum E_Buildings
	{
		FARM,
		FIELDS,
		TOWER
	}
	
	
}

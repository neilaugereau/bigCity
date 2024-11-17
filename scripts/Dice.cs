
using Godot;
using System;

namespace BigCity.scripts;

public partial class Dice : Node
{
	[Export] private PackedScene objectToSpawn;
	public int diceNumber;
	public int DiceValues =0;
	public int ThrowDice()
	{
		for (int i = 0; i < diceNumber; i++)
		{
			Node DiceObject = objectToSpawn.Instantiate();
			AddChild(DiceObject); 
			if (DiceObject is RigidBody3D firstRigidBody)
			{
				firstRigidBody.Position = new Vector3(0, 5, 0);
				
			}
			DiceValues +=
		}
		return DiceValues;
	}
}

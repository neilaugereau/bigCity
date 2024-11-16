
using Godot;
using System;

namespace BigCity.scripts;

public partial class Dice : Node
{
	Random random = new();
	
	[Export] private PackedScene objectToSpawn;  // Scène assignable dans l'éditeur

	public override void _Ready()
	{
		base._Ready();
		Node firstObject = objectToSpawn.Instantiate();
		AddChild(firstObject); 
		if (firstObject is RigidBody3D firstRigidBody)
		{
		 	firstRigidBody.Position = new Vector3(0, 5, 0);  
		}
	}

	public int ThrowDice()
	{
		
		int currentFaces = random.Next(1,6);
		
		return currentFaces;
	}
}

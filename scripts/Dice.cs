
using Godot;
using System;

namespace BigCity.scripts;

public partial class Dice : RigidBody3D
{
	Random random = new();
	public int ThrowDice()
	{
		int currentFaces = random.Next(1,6);
		
		return currentFaces;
	}
}

using Godot;
using System;

public partial class CardSlot : Node2D
{

	public bool cardInSlot = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//this.GetNode<Area2D>("Area2D").CollisionMask;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

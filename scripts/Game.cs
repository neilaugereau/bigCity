using Godot;
using System;

public partial class Game : Node
{
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

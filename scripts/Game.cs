using Godot;
using System;

public partial class Game : Node
{
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }

	bool turn; // true = player's turn,  false = enemy's turn.
	public override void _Ready()
	{
		mainPlayer = new player();
		Enemy = new player();
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

using Godot;
using System;

public partial class Game : Node
{
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	
	public player currentPlayer { get; private set; }
	public player opposingPlayer { get; private set; }
	public player[] allPlayers { get; private set; }
	

	bool turn; // true = player's turn,  false = enemy's turn.
	public override void _Ready()
	{
		mainPlayer = new player();
		Enemy = new player();
		currentPlayer = mainPlayer;
		opposingPlayer = Enemy;
		allPlayers = new player[] { mainPlayer, Enemy };

		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

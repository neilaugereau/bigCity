using Godot;
using System;

public partial class PlayGameButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _on_play_game_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
	}
}

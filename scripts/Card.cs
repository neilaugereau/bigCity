using Godot;
using System;

public partial class Card : Node2D
{
	[Signal]
	public delegate void hoveredEventHandler(Card card);

	[Signal]
	public delegate void hoveredOffEventHandler(Card card);

	public Vector2 startingPosition ;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var cardManager = GetParent() as CardManager;
		if (cardManager != null)
		{
			cardManager.ConnectCardsSignals(this);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_area_2d_mouse_entered()
	{
		EmitSignal("hovered", this);
	}

	public void _on_area_2d_mouse_exited()
	{
		EmitSignal("hoveredOff", this);
	}
}

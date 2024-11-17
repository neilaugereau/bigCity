using Godot;
using System;
using System.Collections.Generic;

public partial class Deck : Node2D
{
	// Called when the node enters the scene tree for the first time.
	List<Card> playerDeck = new List<Card>();

    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void DrawCard()
	{
	}
}

using Godot;
using System;
using System.Collections.Generic;
public partial class player : Node
{
	Game game;
	
	private var buildings = Godot.Collections.Dictionary {
		{ECardType.Monument, new Godot.Collections.Array<card_base>()},
		{ECardType.Special, new Godot.Collections.Array<card_base>()},
		{ECardType.Red, new Godot.Collections.Array<card_base>()},
		{ECardType.Green, new Godot.Collections.Array<card_base>()},
		{ECardType.Blue, new Godot.Collections.Array<card_base>()},
	};
	
	public void ExecuteCardSpecial(ECardType type)
	{
		foreach(var card in buildings[type])
			card.Activate(game);
	}
	
	public void DrawCard(Piles stack)
	{
		var card = stack.GetCards();
		
		buildings[card.Type].Add(card);
	}
	
	public player() : base()
	{
		buildings = new List<card_base>();
	}
}

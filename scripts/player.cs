using BigCity.scripts;
using Godot;
using System;
using System.Collections.Generic;
public partial class player : Node
{
	public Controller playerController {  get; private set; }

	Game game;

	public Money money;
	
	private Godot.Collections.Dictionary<ECardType, Godot.Collections.Array<card_base>> buildings = new() {
		{ECardType.Monument, new Godot.Collections.Array<card_base>()},
		{ECardType.Special, new Godot.Collections.Array<card_base>()},
		{ECardType.Red, new Godot.Collections.Array<card_base>()},
		{ECardType.Green, new Godot.Collections.Array<card_base>()},
		{ECardType.Blue, new Godot.Collections.Array<card_base>()},
	};
	
	

	public void ExecuteCardSpecial(ECardType type)
	{
		foreach(var card in buildings[type])
			card.Activate(game, this);
	}
	
	public void DrawCard<T>(Piles<T> stack) where T : card_base, new()
	{
		var card = stack.GetCards();
		
		buildings[card.Type].Add(card);
	}
}

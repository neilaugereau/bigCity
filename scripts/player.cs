using BigCity.scripts;
using Godot;
using System;
using System.Collections.Generic;
public partial class player : Node
{
	public Controller playerController {  get; private set; }

	Game game;
	
	private Godot.Collections.Dictionary<ECardColor, Godot.Collections.Array<Card>> buildings = new() {
		{ECardColor.Monument, new Godot.Collections.Array<Card>()},
		{ECardColor.Special, new Godot.Collections.Array<Card>()},
		{ECardColor.Red, new Godot.Collections.Array<Card>()},
		{ECardColor.Green, new Godot.Collections.Array<Card>()},
		{ECardColor.Blue, new Godot.Collections.Array<Card>()},
	};
	
	

	public void ExecuteCardSpecial(ECardColor type)
	{
		foreach(var card in buildings[type])
			card.OnActivate(game, this);
	}
	
	public void DrawCard(Piles stack)
	{
		var card = stack.GetCards();
		
		buildings[card.Type].Add(card);
	}
}

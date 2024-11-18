using BigCity.scripts;
using Godot;
using System;

public partial class player : Node
{
	public event EventHandler PlayerChoiceEvent;

	public int money = 0;
	Game game;
	
	public Godot.Collections.Dictionary<ECardType, Godot.Collections.Array<CardBase>> buildings = new() {
		{ECardType.Agricole, new Godot.Collections.Array<CardBase>()},
		{ECardType.Farm, new Godot.Collections.Array<CardBase>()},
		{ECardType.Resources, new Godot.Collections.Array<CardBase>()},
		{ECardType.Shop, new Godot.Collections.Array<CardBase>()},
		{ECardType.Factory, new Godot.Collections.Array<CardBase>()},
		{ECardType.Market, new Godot.Collections.Array<CardBase>()},
		{ECardType.Restauration, new Godot.Collections.Array<CardBase>()},
		{ECardType.Special, new Godot.Collections.Array<CardBase>()},
		{ECardType.Monument, new Godot.Collections.Array<CardBase>()},
	};

    public void ExecuteCardSpecial(ECardType type, int diceValue)
	{
		foreach(var card in buildings[type])
			if(diceValue >= card.DiceRange[0] && diceValue <= card.DiceRange[1])
				card.OnActivate(new CardActivationEventArgs(game));
	}
	
	public void DrawCard(Piles stack)
	{
		var card = stack.GetCards(this);
		
		buildings[card.CardType].Add(card);
	}

	public void OnPlayerChoiceEvent()
	{
		PlayerChoiceEvent?.Invoke(this, null);
	}
	
	
}

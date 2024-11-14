using Godot;
using System;
using BigCity.scripts.cards;

public partial class Stadium: BlueCard
{
	public Stadium() : base(4)
	{
		Type = ECardType.Blue;
		Name = "Stadium";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 6;
		
	}
	
	
}

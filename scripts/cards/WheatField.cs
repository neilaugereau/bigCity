using Godot;
using System;
using BigCity.scripts.cards;

public partial class WheatField : BlueCard
{
	public WheatField() : base(1)
	{
		Type = ECardType.Blue;
		Name = "Wheat Field";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 1;
		
	}
	
	
}

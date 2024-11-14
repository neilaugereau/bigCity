using Godot;
using System;
using BigCity.scripts.cards;

public partial class Farm: BlueCard
{
	public Farm() : base(1)
	{
		Type = ECardType.Blue;
		Name = "Farm";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 2;
		
	}
	
	
}

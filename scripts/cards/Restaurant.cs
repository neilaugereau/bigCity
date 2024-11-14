using Godot;
using System;
using BigCity.scripts.cards;

public partial class Restaurant: RedCard
{
	public Restaurant() : base(2)
	{
		Type = ECardType.Red;
		Name = "Restaurant";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 4;
		
	}
	
	
}

using Godot;
using System;
using BigCity.scripts.cards;

public partial class Bakery: GreenCard
{
	public Bakery() : base(2)
	{
		Type = ECardType.Green;
		Name = "Bakery";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 1;
		
	}
	
	
}

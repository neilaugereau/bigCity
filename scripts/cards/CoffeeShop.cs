using Godot;
using System;
using BigCity.scripts.cards;

public partial class CoffeeShop: RedCard
{
	public CoffeeShop() : base(1)
	{
		Type = ECardType.Red;
		Name = "Coffee Shop";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 2;
		
	}
	
	
}

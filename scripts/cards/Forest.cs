using Godot;
using System;
using BigCity.scripts.cards;

public partial class Forest: BlueCard
{
	public Forest() : base(1)
	{
		Type = ECardType.Blue;
		Name = "Forest";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 2;
		
	}
	
	
}

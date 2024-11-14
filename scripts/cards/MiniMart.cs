using Godot;
using System;
using BigCity.scripts.cards;

public partial class MiniMart: GreenCard
{
	public MiniMart() : base(3)
	{
		Type = ECardType.Green;
		Name = "MiniMart";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 2;
	}
}

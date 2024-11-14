using Godot;
using System;

public partial class WheatField : card_base
{
	public WheatField()
	{
		Type = ECardType.Blue;
		CardName = "Wheat Field";
		EffectDescription = "During anyone's turn, recieve a coin from the bank.";
		Price = 1;
	}
	
	
}

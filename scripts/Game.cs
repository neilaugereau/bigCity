using Godot;
using System;

public partial class Game : Node
{
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	public player[] allPlayers { get; private set; }
	
	public Godot.Collections.Array<DiceC> players { get; private set; }
	public override void _Ready()
	{
		mainPlayer = new player();
		Enemy = new player();
		allPlayers = new player[] { mainPlayer, Enemy };
		base._Ready();
	}

	public void Round()
	{
		int DiceValue = allPlayers[0].ThrowDice();
		foreach (player p in allPlayers)
		{
			p.ExecuteCardSpecial(ECardType.Farm,DiceValue);
			p.ExecuteCardSpecial(ECardType.Agricole,DiceValue);
			p.ExecuteCardSpecial(ECardType.Resources,DiceValue);
		}
		foreach (player p in allPlayers)
		{
			if(p== allPlayers[0])
				continue;
			p.ExecuteCardSpecial(ECardType.Restauration,DiceValue);
		}
		allPlayers[0].ExecuteCardSpecial(ECardType.Shop,DiceValue);
		allPlayers[0].ExecuteCardSpecial(ECardType.Factory,DiceValue);
		allPlayers[0].ExecuteCardSpecial(ECardType.Market,DiceValue);
		Shift(allPlayers);
	}
	
	public player[] Shift(player[] playerArray)
	{
		player[] output = new player[playerArray.Length];
		for (int i = 0; i < playerArray.Length; i++)
			output[i] = playerArray[(i + 1) % playerArray.Length];
		return output;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

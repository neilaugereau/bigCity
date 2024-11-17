using Godot;
using System;

public partial class Game : Node
{
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	public player[] players { get; private set; }
	public DiceManager diceManager { get; private set; }
	public override void _Ready()
	{
		mainPlayer = new player();
		Enemy = new player();
		players = new player[] { mainPlayer, Enemy };
		diceManager = new DiceManager();

		diceManager.AllDiceLanded += Round;
		diceManager.ThrowDices(1);
		base._Ready();
	}

	public void Round(object sender, LandedEventArgs args)
	{
		foreach (player p in players)
		{
			p.ExecuteCardSpecial(ECardType.Farm,args.Value);
			p.ExecuteCardSpecial(ECardType.Agricole, args.Value);
			p.ExecuteCardSpecial(ECardType.Resources, args.Value);
		}
		foreach (player p in players)
		{
			if(p== players[0])
				continue;
			p.ExecuteCardSpecial(ECardType.Restauration, args.Value);
		}
		players[0].ExecuteCardSpecial(ECardType.Shop, args.Value);
		players[0].ExecuteCardSpecial(ECardType.Factory, args.Value);
		players[0].ExecuteCardSpecial(ECardType.Market, args.Value);
		Shift(players);
		diceManager.ThrowDices(1);
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

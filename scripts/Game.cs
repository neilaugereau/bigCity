using Godot;
using System;
namespace BigCity.scripts;
public partial class Game : Node
{
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	public player[] players { get; private set; }
	public DiceManager diceManager { get; private set; }

	public Piles[] cardStack;
	public override void _Ready()
	{
		mainPlayer = new player();
		Enemy = new player();
		players = new player[] { mainPlayer, Enemy };
		cardStack = new Piles[]
		{
			new Piles(E_Building.FARM, 6),   
			new Piles(E_Building.FIELD, 4),   
			new Piles(E_Building.FOREST, 6),
			new Piles(E_Building.MINE, 6),   
			new Piles(E_Building.ORCHARD, 6),   
			new Piles(E_Building.CAFE, 6),
			new Piles(E_Building.RESTAURANT, 6),   
			new Piles(E_Building.BAKERY, 4),   
			new Piles(E_Building.SUPERMARKET, 6),
			new Piles(E_Building.FURNITURE_FACTORY, 6),
			new Piles(E_Building.VEGETABLES_MARKET, 6),   
			new Piles(E_Building.CHEESE_SHOP, 6),   
			new Piles(E_Building.TV_CHANNEL, 6),
			new Piles(E_Building.STADIUM, 4),   
			new Piles(E_Building.BUSINESS_CENTER, 4),   
			new Piles(E_Building.TOWER, 4),
			new Piles(E_Building.TRAIN_STATION, 4),   
			new Piles(E_Building.AMUSEMENT_PARK, 4),
			new Piles(E_Building.MALL, 4)
		};
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

		players[0].DrawCard(cardStack[0]); // A RETRAVAILLER
		
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

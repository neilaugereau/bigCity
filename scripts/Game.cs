using Godot;
using System;
public partial class Game : Node
{
	[Export] Control gameUI;
	[Export] Node diceManager;
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	public player[] players { get; private set; }
	public int mainPlayerIndex { get; private set; }

	public Piles[] cardStack;
	
	[Export]
	public Node2D cardManager;
	public override void _Ready()
	{
		mainPlayer = new player();
		Enemy = new player();
		players = new player[] { mainPlayer, Enemy };

		((DiceManager)diceManager).AllDiceLanded += Round;

		((GameUI)gameUI).BtnDicePressed += OnPlayerThrowDices;
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
		((DiceManager)diceManager).AllDiceLanded += Round;
		((CardManager)cardManager).chooseCard += OnChooseCard;
        base._Ready();
		
	}

	public void OnChooseCard(object sender, ChooseCardEventArgs e)
	{
		foreach (Piles p in cardStack)
		{
			if (p.card == e.building)
			{
				mainPlayer.DrawCard(p);
				break;
			}
		}

	}


	public void Round(object sender, LandedEventArgs args)
	{
		return;
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
	}
	
	public void OnPlayerThrowDices(object sender, EventArgs args)
	{
		((DiceManager)diceManager).ThrowDices(1);
	}

	public player[] Shift(player[] playerArray)
	{
		player[] output = new player[playerArray.Length];
		for (int i = 0; i < playerArray.Length; i++)
			output[i] = playerArray[(i + 1) % playerArray.Length];

		mainPlayerIndex -= 1;
		if (mainPlayerIndex < 0)
			mainPlayerIndex = players.Length - 1;

		return output;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

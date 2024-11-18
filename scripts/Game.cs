using Godot;
using System;
using System.Linq;
public partial class Game : Node
{
	[Export] Node3D playerGrid;

	[Export] Control gameUI;
	[Export] Node diceManager;
	[Export] Node3D enemyGrid;
	public player mainPlayer { get; private set; }
	public player Enemy { get; private set; }
	public player[] players { get; private set; }
	public int mainPlayerIndex { get; private set; }

	public Piles[] cardStack;

	private bool playerCanThrowDice = false;
	
	[Export]
	public Node2D cardScene;
	public override void _Ready()
	{
		cardScene.Hide();
		mainPlayer = new player();
		Enemy = new player();
		players = new player[] { mainPlayer, Enemy };

		mainPlayer.PlayerChoiceEvent += PlayerAction;
		Enemy.PlayerChoiceEvent += EnemyAction;


		// TODO : change OnPlayerThrowDices

		
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
		((CardManager)(cardScene.GetNode<Node2D>("CardManager"))).chooseCard += OnChooseCard;
		base._Ready();
		
	}

	public void OnChooseCard(object sender, ChooseCardEventArgs e)
	{
		if (!((GridSelection)playerGrid).PlaceTileReleaseCard(e.building))
			return;

		foreach (Piles p in cardStack)
		{
			if (p.card == e.building)
			{
				mainPlayer.DrawCard(p);
				break;
			}
		}

		playerCanThrowDice = true;

	}

	
	public void OnPlayerThrowDices(object sender, EventArgs args)
	{
		int v = randomDiceValue();
		Round(sender, v);
	}
	
	public void Round(object sender, int v)
	{
		foreach (player p in players)
		{
			p.ExecuteCardSpecial(ECardType.Farm,v);
			p.ExecuteCardSpecial(ECardType.Agricole, v);
			p.ExecuteCardSpecial(ECardType.Resources, v);
		}
		foreach (player p in players)
		{
			if(p== players[0])
				continue;
			p.ExecuteCardSpecial(ECardType.Restauration, v);
		}
		players[0].ExecuteCardSpecial(ECardType.Shop, v);
		players[0].ExecuteCardSpecial(ECardType.Factory, v);
		players[0].ExecuteCardSpecial(ECardType.Market, v);

		players[0].OnPlayerChoiceEvent();
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

	public void PlayerAction(object sender, EventArgs args)
	{
		cardScene.Show();
	}

	public void EnemyAction(object sender, EventArgs args)
	{
		player p = (player)sender;

		Piles[] buyablePile = new Piles[cardStack.Length];
		foreach(var pile in cardStack)
		{
			if (p.money > Globals.Building[pile.card].Price)
				buyablePile.Append(pile);
		}

		p.DrawCard(buyablePile[GD.Randi() % buyablePile.Length]);

		players = Shift(players);
	}
	
	public int randomDiceValue()
	{
		Random r = new Random();
		int rInt = r.Next(0, 6);
		return rInt;
	}
}



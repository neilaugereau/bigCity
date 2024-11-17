using Godot;
using System;

public class CardActivationEventArgs : EventArgs
{
	public Game game { get; set; }

	public CardActivationEventArgs(Game game)
	{
		this.game = game;
	}
}

public partial class CardBase : Node
{

	public static readonly Color[] CARD_COLORS = new Color[5] {
		new Color("fcf6a0"),
		new Color("9275b5"),
		new Color("f04438"),
		new Color("65bc6b"),
		new Color("57a0d7")
	};

	public static Color GetColorFromCardColor(ECardColor color)
	{
		return CARD_COLORS[(int)color];
	}

	public ECardType CardType;
	public ECardColor CardColor;
	public string CardName;
	public string EffectDescription;
	public int Price;
	public int[] DiceRange;
	public int Gain = 0;
	public ECardType CountType;
	public Mesh BuildingMesh;
	
	public event EventHandler<CardActivationEventArgs> activationEvent;
	
	public CardBase(ECardColor color, ECardType type, string name, string effectDesc, int price, Mesh mesh, int minDiceRange, int maxDiceRange, int gain = 0, ECardType cardType = ECardType.Farm)
	{
		CardType = type;
		CardColor = color;
		CardName = name;
		EffectDescription = effectDesc;
		Price = price;
		BuildingMesh = mesh;
		CountType = cardType;

		if(minDiceRange == maxDiceRange)
			DiceRange = new int[1] {minDiceRange};
		else
			DiceRange = new int[2] {minDiceRange, maxDiceRange};

		Gain = gain;
	}
	
	public void OnActivate(CardActivationEventArgs args)
	{
		activationEvent?.Invoke(this, args);
	}
}

using Godot;
using System;

public partial class Card : Node
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

	public ECardColor CardColor;
	public string CardName;
	public string EffectDescription;
	public int Price;
	public int[] DiceRange;
	public Mesh BuildingMesh;
	
	public event EventHandler activationEvent;
	
	public Card(ECardColor color, string name, string effectDesc, int price, Mesh mesh, int minDiceRange, int maxDiceRange)
	{
		CardColor = color;
		CardName = name;
		EffectDescription = effectDesc;
		Price = price;
		BuildingMesh = mesh;

		if(minDiceRange == maxDiceRange)
			DiceRange = new int[1] {minDiceRange};
		else
			DiceRange = new int[2] {minDiceRange, maxDiceRange};
		
	}
	
	public void OnActivate()
	{
		activationEvent?.Invoke(this, null);
	}
}

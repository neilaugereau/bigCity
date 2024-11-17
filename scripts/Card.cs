using Godot;
using System;

<<<<<<< HEAD
public partial class Card : Node2D
{
    [Signal]
    public delegate void hoveredEventHandler(Card card);

    [Signal]
    public delegate void hoveredOffEventHandler(Card card);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        var cardManager = GetParent() as CardManager;
        if (cardManager != null)
        {
            cardManager.ConnectCardsSignals(this);
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void _on_area_2d_mouse_entered()
	{
        EmitSignal("hovered", this);
	}

    public void _on_area_2d_mouse_exited()
	{
        EmitSignal("hoveredOff", this);
    }
=======
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
>>>>>>> e65426c479e2d33c6bbdf06ee3445486b64768a2
}

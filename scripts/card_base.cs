using Godot;
using System;

public partial class card_base : Node
{
	public ECardType Type{get;protected set;}
	public string CardName{get;protected set;}
	public string EffectDescription{get; protected set;}
	public int Price{get;protected set;}
	public Mesh BuildingMesh{get;protected set;}
	
	public card_base(ECardType type, string name, string effectDesc, int price, Mesh mesh)
	{
		Type = type;
		CardName = name;
		EffectDescription = effectDesc;
		Price = price;
		BuildingMesh = mesh;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public virtual void Activate(Game game, player owner) {}
}

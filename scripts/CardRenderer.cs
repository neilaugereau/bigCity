using Godot;
using System;

public partial class CardRenderer : Node2D
{
	private static Texture2D[] iconTextures = new Texture2D[8] {
		GD.Load<Texture2D>("res://assets/game/cards/wheat.png"),
		GD.Load<Texture2D>("res://assets/game/cards/cow.png"),
		GD.Load<Texture2D>("res://assets/game/cards/gear.png"),
		GD.Load<Texture2D>("res://assets/game/cards/shop.png"),
		GD.Load<Texture2D>("res://assets/game/cards/factory.png"),
		GD.Load<Texture2D>("res://assets/game/cards/melon.png"),
		GD.Load<Texture2D>("res://assets/game/cards/cup.png"),
		GD.Load<Texture2D>("res://assets/game/cards/tower.png")
	};

	public E_Building cardBuilding = E_Building.FARM;
	
	public CardRenderer()
	{

	}

	public CardRenderer(E_Building building)
	{
		cardBuilding = building;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        var subViewport = GetNode<SubViewport>("SubViewportContainer/SubViewport");
        subViewport.RenderTargetUpdateMode = SubViewport.UpdateMode.Once;
        subViewport.RenderTargetClearMode = SubViewport.ClearMode.Never;

        ((ShaderMaterial)GetNode<Sprite2D>("Overlay").Material).SetShaderParameter("color", CardBase.CARD_COLORS[(int)Globals.Building[cardBuilding].CardColor]);
		((ShaderMaterial)GetNode<MeshInstance2D>("MeshInstance2D").Material).SetShaderParameter("color", new Color(0.7f, 0.7f, 0.7f, 1.0f) * CardBase.CARD_COLORS[(int)Globals.Building[cardBuilding].CardColor]);

		GetNode<RichTextLabel>("CoinLabel").Text = Globals.Building[cardBuilding].Price.ToString();

		int[] diceRange = Globals.Building[cardBuilding].DiceRange;
		RichTextLabel diceRangeText = GetNode<RichTextLabel>("DiceLabel");
		
		RichTextLabel nameLabel = GetNode<RichTextLabel>("NameLabel");
		nameLabel.Text = "[center]" + Globals.Building[cardBuilding].CardName;
		nameLabel.AddThemeColorOverride("default_color", new Color(0.7f, 0.7f, 0.7f, 1.0f) *CardBase.CARD_COLORS[(int)Globals.Building[cardBuilding].CardColor]);

		GetNode<RichTextLabel>("DescriptionLabel").Text = "[center]" + Globals.Building[cardBuilding].EffectDescription;

		if (diceRange.Length == 1)
			diceRangeText.Text = "[center]" + diceRange[0].ToString();
		else
			diceRangeText.Text = "[center]" + $"{diceRange[0]}~{diceRange[1]}";

		GetNode<Sprite2D>("IconSprite").Texture = iconTextures[Mathf.Min((int)Globals.Building[cardBuilding].CardType, 7)];
		GetNode<MeshInstance3D>("SubViewportContainer/SubViewport/Node3D/MeshInstance3D").Mesh = Globals.Building[cardBuilding].BuildingMesh;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

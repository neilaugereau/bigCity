using Godot;
using System;
using System.Collections.Generic;

public partial class Deck : Node2D
{
    const string CARD_SCENE_PATH = "res://prefabs/Card.tscn";
    const float CARD_WIDTH = 120f;

    // Called when the node enters the scene tree for the first time.
    List<Card> playerDeck = new List<Card>();

    private float HAND_Y_POSITION;
    private float centerScreenX;

	public override void _Ready()
	{
        centerScreenX = GetViewportRect().Size.X / 2;
        HAND_Y_POSITION = GetViewportRect().Size.Y - (CARD_WIDTH);

        for (int i = 0; i < 10; i++) 
        {
            var dummyCard = new Card
            {
                Name = $"Card{i}"
            };
            playerDeck.Add(dummyCard);
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void DrawCard()
	{
        var cardDrawn = playerDeck[0];
        playerDeck.RemoveAt(0);

        //if player draw the last card in the deck, disable the deck
        if(playerDeck.Count == 0)
        {
            this.GetNode<CollisionShape2D>("../Area2D/CollisionShape2D").Disabled = true;
            this.GetNode<Sprite2D>("Sprite2D").Visible = true;
        }

        // Preload the card scene
        PackedScene cardScene = GD.Load<PackedScene>(CARD_SCENE_PATH);

        // Instantiate and add the cards to the hand
        var newCard = cardScene.Instantiate<Card>();

        // Add the card to the scene
        this.GetNode<CardManager>("../CardManager").AddChild(newCard);

        // Set card properties (optional, depending on the card design)
        newCard.Name = "Card";

        GetNode<PlayerHand>("../PlayerHand").AddCardToHand(newCard);

    }
}

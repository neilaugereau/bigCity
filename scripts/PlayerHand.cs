using Godot;
using System.Collections.Generic;

public partial class PlayerHand : Node2D
{
    // Constants for the card hand
    const int HAND_COUNT = 4;
    const string CARD_SCENE_PATH = "res://prefabs/Card.tscn";
    const float CARD_WIDTH = 120f;

    private float HAND_Y_POSITION;
    private float centerScreenX;

    // List to store the cards in hand
    private List<Card> playedHand = new List<Card>();
    private PackedScene cardScene;

    public override void _Ready()
    {
        // Calculate hand and screen positions
        centerScreenX = GetViewportRect().Size.X / 2;
        HAND_Y_POSITION = GetViewportRect().Size.Y - (CARD_WIDTH);

        // Preload the card scene
        cardScene = GD.Load<PackedScene>(CARD_SCENE_PATH);

        // Instantiate and add the cards to the hand
        for (int i = 0; i < HAND_COUNT; i++)
        {
            var newCard = cardScene.Instantiate<Card>();

            // Add the card to the scene
            AddChild(newCard);

            // Set card properties (optional, depending on the card design)
            newCard.Name = $"Card_{i}";
            newCard.Position = new Vector2(centerScreenX, HAND_Y_POSITION);

            // Add the card to the hand
            AddCardToHand(newCard);
        }
    }

    public void AddCardToHand(Card card)
    {
        if (!playedHand.Contains(card))
        {
            playedHand.Insert(0, card);
            UpdateHandPosition();
        }
        else
        {
            AnimateCardToPosition(card, card.startingPosition);
        }
    }

    public void UpdateHandPosition()
    {
        for (int i = 0; i < playedHand.Count; i++)
        {
            // Calculate the new card position based on its index
            Vector2 newPosition = new Vector2(CalculateCardPosition(i), HAND_Y_POSITION);
            Card card = playedHand[i];
            card.startingPosition = newPosition;
            AnimateCardToPosition(card, newPosition);
        }
    }

    private float CalculateCardPosition(int index)
    {
        float totalWidth = (playedHand.Count - 1) * CARD_WIDTH;
        float xOffset = centerScreenX + index * CARD_WIDTH - totalWidth / 2;
        return xOffset;
    }

    private void AnimateCardToPosition(Card card, Vector2 newPos)
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(card, "position", newPos, 0.2);
    }

    public void removeCardFromHand(Card card)
    {
        if (playedHand.Contains(card) )
        {
            playedHand.Remove(card);
            UpdateHandPosition();
        }
    }
}

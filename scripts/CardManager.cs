using Godot;
using Godot.Collections;
using System;

public class ChooseCardEventArgs : EventArgs
{
    public E_Building building;

    public ChooseCardEventArgs(E_Building building)
    {
        this.building = building;
    }
    
    
}
public partial class CardManager : Node2D
{
    // Constants defining collision masks for cards and card slots
    const int COLLISION_MASK_CARD = 1;
    const int COLLISION_MASK_CARD_SLOT = 2;
    
    public event EventHandler<ChooseCardEventArgs > chooseCard;
    // The card currently being dragged
    private Node2D _cardBeingDragged;

    // Size of the screen, initialized on game start
    private Vector2 _screenSize;

    // Tracks if the mouse is hovering over a card
    private bool isHoveringOnCard;

    // Reference to the player's hand (to manage card movements)
    public PlayerHand playerHandReference;

    // Called when the scene is ready
    public override void _Ready()
    {
        // Get the size of the screen
        _screenSize = GetViewportRect().Size;

        // Fetch the player hand reference
        playerHandReference = this.GetNode<PlayerHand>("../PlayerHand");

        // Connect the left mouse button release event to the `LeftMouseButtonReleased` method
        this.GetNode<InputManager>("../InputManager").Connect("LeftMouseButtonReleased", new Callable(this, "LeftMouseButtonReleased"));
    }

    // Starts dragging a card
    public void StartDrag(Node2D card)
    {
        _cardBeingDragged = card;
        card.Scale = new Vector2(1, 1); // Reset scale
    }

    // Ends dragging a card
    public void FinishDrag()
    {
        // Reset the card's scale
        _cardBeingDragged.Scale = new Vector2(1.05f, 1.05f);

        // Check if the card can be dropped onto a slot
        CardSlot cardSlotFounded = RaycastCheckForCardSlot() as CardSlot;
        var cardRenderer = ((Card)_cardBeingDragged).GetNode<CardRenderer>("CardRenderer");
        chooseCard?.Invoke(this, new ChooseCardEventArgs(cardRenderer.cardBuilding));
        if (cardSlotFounded != null && !cardSlotFounded.cardInSlot)
        {
            // Remove the card from the player's hand
            playerHandReference.removeCardFromHand((Card)_cardBeingDragged);

            // Position the card at the slot and disable its collision
            _cardBeingDragged.GlobalPosition = cardSlotFounded.GlobalPosition;
            _cardBeingDragged.GetNode<CollisionShape2D>("Area2D/CollisionShape2D").Disabled = true;

            // Mark the slot as occupied
            cardSlotFounded.cardInSlot = true;
        }
        else
        {
            // Return the card to the player's hand if no slot is found
            playerHandReference.AddCardToHand((Card)_cardBeingDragged);
        }

        // Clear the reference to the dragged card
        _cardBeingDragged = null;
    }

    // Connects card signals for hover events
    public void ConnectCardsSignals(Card card)
    {
        GD.Print("Connecting signals...");
        card.Connect("hovered", new Callable(this, "on_hover_over_card"));
        card.Connect("hoveredOff", new Callable(this, "on_hover_off_card"));
    }

    // Called when hovering over a card
    private void on_hover_over_card(Card card)
    {
        if (!isHoveringOnCard)
        {
            isHoveringOnCard = true;
            HighlightCard(card, true); // Highlight the card
        }
    }

    // Called when no longer hovering over a card
    private void on_hover_off_card(Card card)
    {
        if (_cardBeingDragged == null)
        {
            HighlightCard(card, false); // Remove highlight

            // Check if the mouse immediately hovers over another card
            var newCardHovered = RaycastCheckForCard();
            if (newCardHovered is Card newCard)
            {
                HighlightCard(newCard, true); // Highlight the new card
            }
            else
            {
                isHoveringOnCard = false; // No card is being hovered over
            }
        }
    }

    // Triggered when the left mouse button is released
    private void LeftMouseButtonReleased()
    {
        if (_cardBeingDragged != null)
        {
            FinishDrag(); // Finalize the drag operation
        }
    }

    // Highlights or un-highlights a card based on hover state
    private void HighlightCard(Card card, bool hovered)
    {
        if (hovered)
        {
            card.Scale = new Vector2(1.08f, 1.08f); // Slightly enlarge the card
            card.ZIndex = 2; // Bring it to the foreground
        }
        else
        {
            card.Scale = new Vector2(1.0f, 1.0f); // Reset to original size
            card.ZIndex = 1; // Reset z-index
        }
    }

    // Checks for a card slot at the mouse position using a raycast
    private object RaycastCheckForCardSlot()
    {
        var spaceState = GetWorld2D().DirectSpaceState;

        var parameters = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            CollisionMask = COLLISION_MASK_CARD_SLOT // Only consider card slots
        };

        var results = spaceState.IntersectPoint(parameters);
        if (results.Count > 0)
        {
            return ((Area2D)results[0]["collider"].Obj).GetParent(); // Return the parent (slot)
        }
        return null;
    }

    // Checks for a card at the mouse position using a raycast
    private object RaycastCheckForCard()
    {
        var spaceState = GetWorld2D().DirectSpaceState;

        var parameters = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            CollisionMask = COLLISION_MASK_CARD // Only consider cards
        };

        var results = spaceState.IntersectPoint(parameters);
        if (results.Count > 0)
        {
            return GetCardWithHighestZIndex(results); // Return the top-most card
        }
        return null;
    }

    // Finds the card with the highest z-index from the raycast results
    private object GetCardWithHighestZIndex(Array<Dictionary> cards)
    {
        Area2D highestZCard = (Area2D)cards[0]["collider"].Obj;

        int highestZIndex = highestZCard.GetParent() is Node2D parentNode
            ? parentNode.ZIndex
            : highestZCard.ZIndex;

        for (int i = 1; i < cards.Count; i++)
        {
            if (cards[i]["collider"].Obj is Area2D card)
            {
                int parentZIndex = card.GetParent() is Node2D cardParent
                    ? cardParent.ZIndex
                    : card.ZIndex;

                if (card.ZIndex > highestZIndex)
                {
                    highestZIndex = card.ZIndex;
                    highestZCard = card;
                }
            }
        }
        return highestZCard.GetParent();
    }

    // Called every frame to update the card position if dragging
    public override void _Process(double delta)
    {
        if (_cardBeingDragged != null)
        {
            Vector2 mousePos = GetGlobalMousePosition();

            // Clamp the card's position to stay within the screen
            _cardBeingDragged.GlobalPosition = new Vector2(
                Mathf.Clamp(mousePos.X, 0, _screenSize.X),
                Mathf.Clamp(mousePos.Y, 0, _screenSize.Y)
            );
        }
    }
}

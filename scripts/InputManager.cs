using Godot;
using System;

public partial class InputManager : Node2D
{
    [Signal]
    public delegate void LeftMouseButtonClickedEventHandler();

    [Signal]
    public delegate void LeftMouseButtonReleasedEventHandler();

    // Collision masks for cards and the deck
    const int COLLISION_MASK_CARD = 1;
    const int COLLISION_MASK_DECK = 4;

    // References to the CardManager and Deck
    CardManager cardManagerReference;
    Deck deckReference;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        // Fetch references to CardManager and Deck in the scene tree
        cardManagerReference = this.GetNode<CardManager>("../CardManager");
        deckReference = this.GetNode<Deck>("../Deck");
	}

    // Processes input events, specifically mouse clicks
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left)
            {
                if (mouseEvent.Pressed)
                {
                    EmitSignal("LeftMouseButtonClicked");
                    RaycastAtCursor();
                }
                else
                {
                    EmitSignal("LeftMouseButtonReleased");
                }
            }
        }
    }


    // Casts a ray from the cursor to detect objects
    private object RaycastAtCursor()
    {
        var spaceState = GetWorld2D().DirectSpaceState;

        // Set up parameters for a point query at the cursor's global position
        var parameters = new PhysicsPointQueryParameters2D
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true, // Only consider areas
        };

        // Perform the raycast and get results
        var results = spaceState.IntersectPoint(parameters);

        if (results.Count > 0)
        {
            // Get the collision mask of the first object hit
            var resultCollisionMask = ((Area2D)results[0]["collider"].Obj).CollisionMask;

            if (resultCollisionMask == COLLISION_MASK_CARD)
            {
                // Fetch the parent node of the collider (the card)
                var cardFound = ((Area2D)results[0]["collider"].Obj).GetParent();

                if (cardFound != null)
                {
                    // Start dragging the card through the CardManager
                    cardManagerReference.StartDrag((Node2D)cardFound);
                }
            }
            else if (resultCollisionMask == COLLISION_MASK_DECK)
            {
                // Trigger the deck's DrawCard method
                deckReference.DrawCard();
            }
        }
        return null;
    }
}
